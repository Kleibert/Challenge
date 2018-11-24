using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectChallenge.Models;
using Microsoft.Extensions.DependencyInjection;
using projectChallenge.Authentication;
using System.Web;
using Microsoft.Net.Http.Headers;
using System.Collections;

namespace projectChallenge.Controllers
{
    public class ChallengeController:Controller
    {
        private readonly ContextChallenge contextChallenge;
       /* public void ConfigureServices(IServiceCollection services, string token)
        {
            // Add authentication 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CustomAuthOptions.DefaultScheme;
                options.DefaultChallengeScheme = CustomAuthOptions.DefaultScheme;
            })

             // Multiple auth keys
             .AddCustomAuth(options =>
             {
                 //var key = "oi";
                 options.AuthKey = token;


             });
          
        }*/


        public ChallengeController(ContextChallenge _contextChallenge)
        {
            contextChallenge = _contextChallenge;
        }
        [HttpPost]
        public ActionResult Log()
        {
            User user = new User
            {
                Username = Request.Form["username"],
                Password = Request.Form["password"]
            };
          
            User userDataBase = contextChallenge.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (userDataBase!=null)
            {
                var token = contextChallenge.Tokens.Where(t => t.UserId == userDataBase.Userid);
                foreach (Token to in token)
                {
                    contextChallenge.Tokens.Remove(to);
                }
                contextChallenge.SaveChanges();

                List<Token> tokens = new List<Token>();

                for (int i = 0; i < 50; i++)
                {
                    Token nToken = new Token
                    {
                        ValideDate = DateTime.Now,
                        UserId = userDataBase.Userid
                    };
                    nToken.TokenCreate = nToken.CreateToken();
                    tokens.Add(nToken);
                }

                foreach (Token el in tokens)
                {
                    contextChallenge.Tokens.Add(el);
                   
                }
                contextChallenge.SaveChanges();
                @ViewData["Tokens"] =tokens;
                return View(user);
            }
            else{

                return View("Index",user);
            }

        }
     
        public IActionResult Index(User response)
        {
           
           Request.Headers.TryGetValue(HeaderNames.UserAgent, out var header);
            ViewData["Agent"] = header;
            ViewData["Response"] = response;

            return View(response);
        }
       
        public IActionResult Singup(){
            return View();
        }
        [HttpPost("/api/GerarToken")]
        public JsonResult GerarToken([FromBody] Parameter parameter)
        {
            var userDataBase = contextChallenge.Users.Where(u => u.Username == parameter.username && u.Password == parameter.password).FirstOrDefault();
            var tokens = contextChallenge.Tokens.Where(user => user.UserId == userDataBase.Userid);
            List<string>listToken=new List<string>();
            foreach(Token element in tokens){
                listToken.Add(element.TokenCreate);
            }
            if (userDataBase != null)
            {
                return Json(new
                {
                    token = listToken,
                    challengeID = "1270637707"
                });
                
            }
            else
            {
                return Json(new { token = string.Empty });
            }
        }
        [Route("Result")]
        public IActionResult Result(){
            @ViewData["name"] = "Kleibert";
            @ViewData["password"] = "1234";
            return View();
        }
        [Route("js")]
        public JsonResult js(){
            var x = HttpContext.Request.Cookies;
            return Json(x);
        }
        // GET api/values
        [Authorize]
        [Route("api/Valide")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}
