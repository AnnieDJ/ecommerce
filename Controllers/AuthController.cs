using Microsoft.AspNetCore.Mvc;
using ecommerce.Data;
using ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using BCrypt.Net;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly EcommerceDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(EcommerceDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email || u.Name == request.FullName))
            return BadRequest("Email or Username already exists.");

        if (!IsValidPassword(request.Password))
            return BadRequest("Password must be at least 8 characters long, contain at least one uppercase letter and one number.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Name = request.FullName,
            Role = request.Role ?? "user",
            Status = (request.Role == "merchant") ? "inactive" : "active",
            CreatedAt = DateTime.Now
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Register Successfully!" });
    }

    private bool IsValidPassword(string password)
    {
        var passwordPattern = new Regex("^(?=.*[A-Z])(?=.*\\d).{8,}$");
        return passwordPattern.IsMatch(password);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized("User or password wrong!");

        if (user.Role == "merchant" && user.Status == "inactive")
            return Unauthorized("Merchant account awaiting admin approval.");

        var token = GenerateJwtToken(user);
        return Ok(new { message = "Successfully！", token });
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[] {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("Name", user.Name)
        };

        var token = new JwtSecurityToken(
            "your-issuer",
            "your-issuer",
            claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class AuthRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterRequest : AuthRequest
{
    public string FullName { get; set; }
    public string Role { get; set; }
}
