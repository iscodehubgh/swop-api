using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly swopContext _context;

        public UsersController(swopContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users
                                 .Select(x => new ApplicationUser
                                 {
                                     Id = x.Id,
                                     FirstName = x.FirstName,
                                     LastName = x.LastName,
                                     Articles = x.Articles
                                 })
                                 .ToListAsync();
        }

        private bool ArticleExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

