using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoTracker.Data;
using CryptoTracker.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        private UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        { 
            return await _context.Users.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}