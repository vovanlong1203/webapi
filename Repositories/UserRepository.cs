using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Interfaces;

namespace MyWebApi.Repositories;

public class UserRepository : IUserRepository {
    private readonly QuizDbContext _context;

    public UserRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.Include(u => u.Class).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id) {
        return await _context.Users.Include(u => u.Class).FirstOrDefaultAsync(u => u.ClassId == id);
    }

    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    } 

    public async Task<User?> UpdateAsync(int id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null) return null;

        existingUser.Username = user.Username;
        existingUser.PasswordHash = user.PasswordHash;
        existingUser.Email = user.Email;
        existingUser.FullName = user.FullName;
        existingUser.Role = user.Role;
        existingUser.ClassId = user.ClassId;
        existingUser.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteAsync(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
        return true; 
    }
}