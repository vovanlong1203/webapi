using MyWebApi.DTOs;

namespace MyWebApi.Interfaces;
public interface IExamService
{
    Task<IEnumerable<ExamDto>> GetAllAsync();
    Task<ExamDto?> GetByIdAsync(int id);
    Task<ExamDto> CreateAsync(CreateExamDto dto);
    Task<ExamDto?> UpdateAsync(int id, CreateExamDto dto);
    Task<bool> DeleteAsync(int id);
}