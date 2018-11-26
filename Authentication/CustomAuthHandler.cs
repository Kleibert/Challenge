using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using projectChallenge.Models;
using System.Collections;

namespace projectChallenge.Authentication
{
    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        private readonly ContextChallenge contextChallenge;

        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ContextChallenge _contextChallenge)

            : base(options, logger, encoder, clock)
        {
            contextChallenge = _contextChallenge;
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Request.Headers.TryGetValue(HeaderNames.UserAgent, out var header);
            Agent agent = new Agent
            {
                AgentUser = header,
                ValideDate = DateTime.Now
            };
            contextChallenge.Agents.Add(agent);
            contextChallenge.SaveChanges();
            // verify  if it's a DDos Ataque
            var agentDate = (from ag in contextChallenge.Agents
                            where (ag.ValideDate <= DateTime.Now) &&
                             (ag.ValideDate >= (DateTime.Now.Subtract(TimeSpan.FromMilliseconds(1000))))
                             select ag).ToList();
            Console.WriteLine("DATA");
           

            foreach (var i in agentDate){
                Console.Write(i.AgentUser + i.ValideDate);
              
            }
            Console.WriteLine("FIM DATA");
            Console.WriteLine( agentDate.Count());
            if(agentDate.Count()>=3){
                Console.WriteLine("Podemos estar recebendo um ataque DDOs");
            }
            // End verify  if it's a DDos Ataque
         
            //Start verify tokens are valides
            string authorizationsTokens = string.Empty;

            if (Request.Headers.TryGetValue(HeaderNames.Authorization, out var headerValues))
            {
                authorizationsTokens = headerValues;
            }
            Console.WriteLine("header=======");
           
            Console.WriteLine(authorizationsTokens);
            var customkey = Options.AuthKey;
            if (!string.IsNullOrEmpty(authorizationsTokens))
            {
                bool verifyTokens = true;
                String[] tokens = authorizationsTokens.Split(",");
                foreach (string element in tokens)
                {
                    var checkToken = contextChallenge.Tokens.Where(t => t.TokenCreate == element).FirstOrDefault();

                    if (checkToken != null)
                    {

                        var date1 = DateTime.Now;
                        var date2 = checkToken.ValideDate;

                        TimeSpan timer = date1 - date2;

                        if (timer.Minutes > 30)
                        {
                            verifyTokens = false;

                        }
                       
                    }

                }
                if (!verifyTokens)
                {
                  
                    return Task.FromResult(AuthenticateResult.Fail("Tokens are expired"));
                }
            }
            //End verify tokens are valides

            // Create authenticated user
            var identitiess = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth for Challenge"), new ClaimsIdentity("Challenge Id :1270637707") };
            var tickets = new AuthenticationTicket(new ClaimsPrincipal(identitiess), Options.Scheme);
            return Task.FromResult(AuthenticateResult.Success(tickets));
        }
    }
}
