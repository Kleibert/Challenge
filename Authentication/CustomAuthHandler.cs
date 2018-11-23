﻿using System.Collections.Generic;
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
          //  CustomAuthOptions.AuthKey =  "134564sad454sdfasd3" ;
           string userId = string.Empty;

            if (Request.Headers.TryGetValue(HeaderNames.Authorization, out var headerValues))
            {
                userId = headerValues;
            }
            Console.WriteLine("header=======");
            Console.WriteLine(userId);
            var customkey = Options.AuthKey;
            if (!string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("custom key=======");
            Console.WriteLine(customkey);
            var checkToken = contextChallenge.Tokens.Where(t => t.TokenCreate == userId).FirstOrDefault();
            Console.WriteLine("custom key=======");
            Console.WriteLine( checkToken.GetType());
           
                if (checkToken.TokenCreate == userId && checkToken != null)
                {
                    var identitiess = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth for Challenge") };
                    var tickets = new AuthenticationTicket(new ClaimsPrincipal(identitiess), Options.Scheme);
                    return Task.FromResult(AuthenticateResult.Success(tickets));
                }
            }
            // Get Authorization header value
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail("Cannot read authorization header."));
            }

            // The auth key from Authorization header check against the configured ones
            if (authorization.Any(key => Options.AuthKey.All(ak => ak != key)))
            {

                return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
            }

            // Create authenticated user
           var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth for Challenge") };
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);
            Console.WriteLine("KEY=>");
            Console.WriteLine("KEY=>", Options.AuthKey);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}