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
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace projectChallenge.Controllers
{
    public class ChallengeController:Controller
    {
        private readonly ContextChallenge contextChallenge;

        public ChallengeController(ContextChallenge _contextChallenge)
        {
            contextChallenge = _contextChallenge;

        }

        public IActionResult Index()
        {

            return View();
        }

        //create method to valide username, password and creating a tokens 
        [HttpPost]
        public ActionResult Log(User userRegistration)
        {
            string pattern = @"(^[1-3]{0,4}$)";
     

            User user = new User();
          
            if (userRegistration != null) {
                user.Username = userRegistration.Username;
                user.Password = userRegistration.Password;
            }
            if (Regex.IsMatch(user.Username, pattern) && Regex.IsMatch(user.Password, pattern))
            {


                User userDataBase = contextChallenge.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (userDataBase != null)
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
                    string autoTokens = "";
                    foreach (Token el in tokens)
                    {
                        contextChallenge.Tokens.Add(el);
                        autoTokens += el.TokenCreate;
                    }
                    contextChallenge.SaveChanges();
                    @ViewData["Tokens"] = tokens;

                    //WebClient client = new WebClient();
                    //client.Headers["Authorization"] = "Basic " + tokens;

                    Response.Headers.Add("Authorization", string.Format(autoTokens) + ";");
                    return View(user);
                }

                else
                {

                    return View("Singin", user);
                }
            }else
            return View("Singin", user);
        }
     
        /// Controller to Sing in the page
        public IActionResult Singin (User response)
        {
            return View(response);
        }
        //Create de view to put the infor for a new user
        public IActionResult Singup(User response){


            return View(response);
        }

       // Registration for new user 
        [HttpPost]
        public IActionResult CreateUser(){
            User user = new User
            {
                Username = Request.Form["username"],
                Password = Request.Form["password"],
                ActiveState = true
            };
            User userDataBase = contextChallenge.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (userDataBase == null)
            {
                contextChallenge.Users.Add(user);
                contextChallenge.SaveChanges();
               
                return RedirectToActionPreserveMethod("Log", "Challenge",(user.Username,user.Password));

            }
                return View("Singup",user);
        }

        //Return all Tokens from une user
        [HttpPost("/api/ReturnTokens")]
        public JsonResult GerarToken([FromBody] Parameter parameter)
        {
            var userDataBase = contextChallenge.Users.Where(u => u.Username == parameter.username && u.Password == parameter.password).FirstOrDefault();
            var tokens = contextChallenge.Tokens.Where(user => user.UserId == userDataBase.Userid);
            // List<string>listToken=new List<string>();
            string listToken = "";
            foreach (Token element in tokens){
                listToken+=element.TokenCreate +",";
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
    
        // GET api/valide this controler is created to verify tokens exitem
        [Authorize]
        [Route("api/Valide")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "Hello", "Congrats tokens valide", " challengeID :1270637707" };
        }
    }
}
