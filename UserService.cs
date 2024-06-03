using CLDVPart1.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CLDVPart1.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}