// MyWebApi/Repositories/ExamRepository.cs
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Interfaces;

namespace MyWebApi.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly QuizDbContext _context;

        public ExamRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.CreatedByNavigation)
                .ToListAsync();
        }

        public async Task<Exam?> GetByIdAsync(int id)
        {
            return await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.CreatedByNavigation)
                .FirstOrDefaultAsync(e => e.ExamId == id);
        }

        public async Task<Exam> CreateAsync(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam?> UpdateAsync(int id, Exam exam)
        {
            var existingExam = await _context.Exams.FindAsync(id);
            if (existingExam == null) return null;

            existingExam.SubjectId = exam.SubjectId;
            existingExam.Title = exam.Title;
            existingExam.Description = exam.Description;
            existingExam.Duration = exam.Duration;
            existingExam.StartTime = exam.StartTime;
            existingExam.EndTime = exam.EndTime;
            existingExam.TotalQuestions = exam.TotalQuestions;
            existingExam.CreatedBy = exam.CreatedBy;

            await _context.SaveChangesAsync();
            return existingExam;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return false;

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}