using MyWebApi.Data;
using MyWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly QuizDbContext _context;

    public SubjectRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Subject>> GetAllAsync()
    {
        return await _context.Subjects.ToListAsync();
    }

    public async Task<Subject?> GetByIdAsync(int id)
    {
        return await _context.Subjects.FindAsync(id);
    }

    public async Task<Subject> CreateAsync(Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return subject;
    }

    public async Task<Subject?> UpdateAsync(int id, Subject subject)
    {
        var existingSubject = await _context.Subjects.FindAsync(id);
        if (existingSubject == null) return null;

        existingSubject.SubjectName = subject.SubjectName;
        existingSubject.Description = subject.Description;

        await _context.SaveChangesAsync();
        return existingSubject;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null) return false;

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();

        return true;
    }

}