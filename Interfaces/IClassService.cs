using MyWebApi.DTOs;

namespace MyWebApi.Interfaces;

public interface IClassService
{
    Task<IEnumerable<ClassDto>> GetAllAsync();
    Task<ClassDto?> GetByIdAsync(int id);
    Task<ClassDto> CreateAsync(CreateClassDto dto);
    Task<ClassDto?> UpdateAsync(int id, CreateClassDto dto);
    Task<bool> DeleteAsync(int id);
}