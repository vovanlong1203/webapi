using MyWebApi.Data;
using MyWebApi.DTOs;
using MyWebApi.Repositories;
using MyWebApi.Interfaces;

namespace MyWebApi.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<IEnumerable<SubjectDto>> GetAllAsync()
    {
        var subjects = await _subjectRepository.GetAllAsync();
        return subjects.Select(s => new SubjectDto
        {
            SubjectId = s.SubjectId,
            SubjectName = s.SubjectName,
            Description = s.Description
        });
    }

    public async Task<SubjectDto?> GetByIdAsync(int id)
    {
        var subject = await _subjectRepository.GetByIdAsync(id);
        if (subject == null) return null;

        return new SubjectDto
        {
            SubjectId = subject.SubjectId,
            SubjectName = subject.SubjectName,
            Description = subject.Description
        };
    }

    public async Task<SubjectDto> CreateAsync(CreateSubjectDto dto)
    {
        var subject = new Subject
        {
            SubjectName = dto.SubjectName,
            Description = dto.Description
        };

        var createdSubject = await _subjectRepository.CreateAsync(subject);
        return new SubjectDto
        {
            SubjectId = createdSubject.SubjectId,
            SubjectName = createdSubject.SubjectName,
            Description = createdSubject.Description
        };
    }

    public async Task<SubjectDto?> UpdateAsync(int id, CreateSubjectDto dto)
    {
        var subject = new Subject
        {
            SubjectName = dto.SubjectName,
            Description = dto.Description,
        };

        var updatedSubject = await _subjectRepository.UpdateAsync(id, subject);
        if (updatedSubject == null) return null;

        return new SubjectDto
        {
            SubjectId = updatedSubject.SubjectId,
            SubjectName = updatedSubject.SubjectName,
            Description = updatedSubject.Description
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _subjectRepository.DeleteAsync(id);
    }

}