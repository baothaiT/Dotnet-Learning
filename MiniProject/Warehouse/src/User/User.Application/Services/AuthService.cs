//using Microsoft.AspNet.Identity;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using User.Application.Interfaces;
//using User.Application.Models;
//using User.Domain.Entities;

//namespace User.Application.Services
//{
//    public class AuthService : IAuthService
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IConfiguration _configuration;

//        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
//        {
//            _userManager = userManager;
//            _configuration = configuration;
//        }

//        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
//        {
//            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
//            var result = await _userManager.CreateAsync(user, request.Password);
//            if (!result.Succeeded)
//                return new AuthResponse { Success = false, Message = "Registration failed" };
//            return new AuthResponse { Success = true, Message = "User registered successfully" };
//        }

//        public async Task<AuthResponse> LoginAsync(LoginRequest request)
//        {
//            var user = await _userManager.FindByEmailAsync(request.Email);
//            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
//                return new AuthResponse { Success = false, Message = "Invalid credentials" };
//            var token = GenerateJwtToken(user);
//            return new AuthResponse { Success = true, Token = token, Message = "Login successful" };
//        }

//        private string GenerateJwtToken(ApplicationUser user)
//        {
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
//                new Claim(JwtRegisteredClaimNames.Email, user.Email)
//            };
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddHours(1),
//                signingCredentials: creds);
//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
