using Dommunity.Application.Services.Persistence;
using Dommunity.Application.ViewModels.User;
using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dommunity.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Login([FromBody] VM_UserLogin userLogin)
    {
        var result = await _authService.LoginAsync(userLogin.UsernameOrEmail, userLogin.Password);
        if (result)
        {
            return Ok("Giriş başarılı");
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Register([FromBody] VM_RegisterUser registerUser)
    {
        User user = new User()
        {
            Email = registerUser.Email,
            Surname = registerUser.Surname,
            Name = registerUser.Name,
            Password = registerUser.Password
        };
        var result = await _authService.RegisterAsync(user);
        if (result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }


}
