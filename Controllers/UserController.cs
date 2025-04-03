using ecommerce.Data;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly EcommerceDbContext _context;

    public UserController(EcommerceDbContext context)
    {
        _context = context;
    }

    // 🔹 获取所有用户
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() // ✅ 确保这里是 `User`
    {
        return await _context.Users.ToListAsync();
    }
}
