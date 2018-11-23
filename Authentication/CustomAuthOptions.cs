using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace projectChallenge.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "custom auth";
        public string Scheme => DefaultScheme;
        public  StringValues AuthKey { get; set; }

      //  public CustomAuthOptions()
        //{
        //    this.AuthKey = new[] { "oi", "custom" };
        //}
    }
}

