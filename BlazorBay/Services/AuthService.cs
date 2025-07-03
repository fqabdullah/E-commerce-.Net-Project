using BlazorBay.Data;
using BlazorBay.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBay.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null && user.PasswordHash == password) // Replace with hashing later
            {
                return user;
            }
            return null;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                    return false;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AuthService] RegisterAsync Error: {ex.Message}");
                return false;
            }
        }
    }
}
