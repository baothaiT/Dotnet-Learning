using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
using System.Security.Claims;

namespace OpenIddictDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager,
                          SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("/connect/token"), IgnoreAntiforgeryToken, Produces("application/json")]
    public async Task<IActionResult> Exchange([FromForm] OpenIddictRequest request)
    {
        if (request.GrantType != OpenIddictConstants.GrantTypes.Password)
            return BadRequest(new OpenIddictResponse
            {
                Error = "unsupported_grant_type",
                ErrorDescription = "Only password grant is supported"
            });

        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return Forbid();
        }

        var identity = new ClaimsIdentity(
            OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
            Claims.Name, Claims.Role);

        identity.AddClaim(Claims.Subject, user.Id);
        identity.AddClaim(Claims.Name, user.UserName);

        var principal = new ClaimsPrincipal(identity);
        principal.SetScopes(OpenIddictConstants.Scopes.OfflineAccess);

        var response = SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        return response;
    }
}
