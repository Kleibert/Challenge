using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectChallenge.Models;
using Microsoft.Extensions.DependencyInjection;
using projectChallenge.Authentication;


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
            @ViewData["User"] = user;
            //contextChallenge.Users.Add(user);
            //contextChallenge.SaveChanges();
            return View();
        }
        [Route("Index")]
        public IActionResult Index(System.Web.Mvc.FormCollection form)
        {
            User user = new User
            {
                Username = form["username"],
                Password = form["password"]
            };
            // contextChallenge.Users.Add(new User { Username = "123", Password = "123", ActiveState = 1 });
            //contextChallenge.SaveChanges();
          /*   Token token = new Token { ValideDate = DateTime.Now, UserId=1 };
            token.TokenCreate = token.CreateToken();
            List<Token> tokens = new List<Token>();
            
            tokens.Add(token);

            contextChallenge.Users.Add(user);
            Token token2 = new Token { ValideDate = DateTime.Now, UserId = 1 };
            token2.TokenCreate = token.CreateToken();
            tokens.Add(token2);
            foreach (Token el in tokens){
                contextChallenge.Tokens.Add(el);
            }
            //contextChallenge.Tokens.Add(tokens);
            contextChallenge.SaveChanges();*/
            return View();
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
