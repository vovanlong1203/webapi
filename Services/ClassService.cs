using MyWebApi.Data;
using MyWebApi.Interfaces;
using MyWebApi.DTOs;

namespace MyWebApi.Services;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<ClassDto>> GetAllAsync()
    {
        var classes = await _classRepository.GetAllAsync();
        return classes.Select(c => new ClassDto
        {
            ClassId = c.ClassId,
            ClassName = c.ClassName,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        });
    }

    public async Task<ClassDto?> GetByIdAsync(int id)
    {
        var classEntity = await _classRepository.GetByIdAsync(id);
        if (classEntity == null) return null;

        return new ClassDto
        {
            ClassId = classEntity.ClassId,
            ClassName = classEntity.ClassName,
            Description = classEntity.Description,
            CreatedAt = classEntity.CreatedAt
        };
    }

    public async Task<ClassDto> CreateAsync(CreateClassDto dto)
    {
        var classEntity = new Class
        {
            ClassName = dto.ClassName,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        var createdClass = await _classRepository.CreateAsync(classEntity);
        return new ClassDto
        {
            ClassId = createdClass.ClassId,
            ClassName = createdClass.ClassName,
            Description = createdClass.Description,
            CreatedAt = createdClass.CreatedAt
        };
    }

    public async Task<ClassDto?> UpdateAsync(int id, CreateClassDto dto)
    {
        var classEntity = new Class
        {
            ClassName = dto.ClassName,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        var updatedClass = await _classRepository.UpdateAsync(id, classEntity);
        if (updatedClass == null) return null;

        return new ClassDto
        {
            ClassId = updatedClass.ClassId,
            ClassName = updatedClass.ClassName,
            Description = updatedClass.Description
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _classRepository.DeleteAsync(id);
    }
}