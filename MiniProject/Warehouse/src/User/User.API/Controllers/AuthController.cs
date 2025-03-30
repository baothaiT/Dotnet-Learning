﻿//using Microsoft.AspNetCore.Mvc;
//using User.Application.Interfaces;
//using User.Application.Models;
//using User.Application.Services;

//namespace User.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;

//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
//        {
//            var result = await _authService.RegisterAsync(request);
//            if (!result.Success)
//                return BadRequest(result);
//            return Ok(result);
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginRequest request)
//        {
//            var result = await _authService.LoginAsync(request);
//            if (!result.Success)
//                return Unauthorized(result);
//            return Ok(result);
//        }
//    }
//}
