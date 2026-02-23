using Microsoft.AspNetCore.Mvc;
using Eventoria.Api.Services;
using Eventoria.Core.Entities;

namespace Eventoria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.AuthenticateAsync(request.Email, request.Password);
        
        if (token == null)
            return Unauthorized(new { message = "Email o contraseña incorrectos" });

        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = await _authService.RegisterAsync(request.Name, request.Email, request.Password);
        
        if (user == null)
            return BadRequest(new { message = "El email ya está registrado" });

        return Ok(new { message = "Usuario registrado exitosamente" });
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class RegisterRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}