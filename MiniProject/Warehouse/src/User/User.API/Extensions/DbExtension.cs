﻿

//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using User.Domain.Entities;
//using User.Persistence.Identity;

//namespace User.API.Extensions
//{
//    public class DbExtension
//    {
//        public static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
//        {


//            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
//            services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            }).AddJwtBearer(options =>
//            {
//                options.RequireHttpsMetadata = false;
//                options.SaveToken = true;
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidIssuer = configuration["Jwt:Issuer"],
//                    ValidAudience = configuration["Jwt:Audience"]
//                };
//            });
//        }
//    }
//}
