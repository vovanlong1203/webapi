// QuizApi/Services/ExamService.cs
using MyWebApi.Data;
using MyWebApi.Interfaces;
using MyWebApi.DTOs;

namespace MyWebApi.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;

        public ExamService(IExamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExamDto>> GetAllAsync()
        {
            var exams = await _repository.GetAllAsync();
            return exams.Select(e => new ExamDto
            {
                ExamId = e.ExamId,
                SubjectId = e.SubjectId,
                Title = e.Title,
                Description = e.Description,
                Duration = e.Duration,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                TotalQuestions = e.TotalQuestions,
                CreatedBy = e.CreatedBy,
                CreatedAt = e.CreatedAt
            });
        }

        public async Task<ExamDto?> GetByIdAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null) return null;

            return new ExamDto
            {
                ExamId = exam.ExamId,
                SubjectId = exam.SubjectId,
                Title = exam.Title,
                Description = exam.Description,
                Duration = exam.Duration,
                StartTime = exam.StartTime,
                EndTime = exam.EndTime,
                TotalQuestions = exam.TotalQuestions,
                CreatedBy = exam.CreatedBy,
                CreatedAt = exam.CreatedAt
            };
        }

        public async Task<ExamDto> CreateAsync(CreateExamDto dto)
        {
            var exam = new Exam
            {
                SubjectId = dto.SubjectId,
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.Duration,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TotalQuestions = dto.TotalQuestions,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.UtcNow
            };

            var createdExam = await _repository.CreateAsync(exam);
            return new ExamDto
            {
                ExamId = createdExam.ExamId,
                SubjectId = createdExam.SubjectId,
                Title = createdExam.Title,
                Description = createdExam.Description,
                Duration = createdExam.Duration,
                StartTime = createdExam.StartTime,
                EndTime = createdExam.EndTime,
                TotalQuestions = createdExam.TotalQuestions,
                CreatedBy = createdExam.CreatedBy,
                CreatedAt = createdExam.CreatedAt
            };
        }

        public async Task<ExamDto?> UpdateAsync(int id, CreateExamDto dto)
        {
            var exam = new Exam
            {
                ExamId = id,
                SubjectId = dto.SubjectId,
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.Duration,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TotalQuestions = dto.TotalQuestions,
                CreatedBy = dto.CreatedBy
            };

            var updatedExam = await _repository.UpdateAsync(id, exam);
            if (updatedExam == null) return null;

            return new ExamDto
            {
                ExamId = updatedExam.ExamId,
                SubjectId = updatedExam.SubjectId,
                Title = updatedExam.Title,
                Description = updatedExam.Description,
                Duration = updatedExam.Duration,
                StartTime = updatedExam.StartTime,
                EndTime = updatedExam.EndTime,
                TotalQuestions = updatedExam.TotalQuestions,
                CreatedBy = updatedExam.CreatedBy,
                CreatedAt = updatedExam.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}