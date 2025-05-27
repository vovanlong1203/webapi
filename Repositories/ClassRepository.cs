using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Interfaces;

namespace MyWebApi.Repositories;

public class ClassRepository : IClassRepository
{
    private readonly QuizDbContext _context;

    public ClassRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await _context.Classes.ToListAsync();
    }

    public async Task<Class?> GetByIdAsync(int id)
    {
        return await _context.Classes.FindAsync(id);
    }

    public async Task<Class> CreateAsync(Class classEntity)
    {
        _context.Classes.Add(classEntity);
        await _context.SaveChangesAsync();
        return classEntity;
    }

    public async Task<Class?> UpdateAsync(int id, Class classEntity)
    {
        var existingClass = await _context.Classes.FindAsync(id);
        if (existingClass == null) return null;

        existingClass.ClassName = classEntity.ClassName;
        existingClass.Description = classEntity.Description;

        await _context.SaveChangesAsync();
        return existingClass;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var classEntity = await _context.Classes.FindAsync(id);
        if (classEntity == null) return false;

        _context.Classes.Remove(classEntity);
        await _context.SaveChangesAsync();

        return true;
    }
}