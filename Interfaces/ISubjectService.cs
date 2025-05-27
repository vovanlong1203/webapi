using MyWebApi.DTOs;

namespace MyWebApi.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllAsync();
        Task<SubjectDto?> GetByIdAsync(int id);
        Task<SubjectDto> CreateAsync(CreateSubjectDto dto);
        Task<SubjectDto?> UpdateAsync(int id, CreateSubjectDto dto);
        Task<bool> DeleteAsync(int id);
    }
}