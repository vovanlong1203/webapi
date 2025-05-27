using Microsoft.AspNetCore.Mvc;
using MyWebApi.DTOs;
using MyWebApi.Interfaces;

namespace QuizApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase 
{
    private readonly ISubjectService _service;

    public SubjectController(ISubjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAll()
    {
        var subjects = await _service.GetAllAsync();
        return Ok(subjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectDto>> GetById(int id)
    {
        var subject = await _service.GetByIdAsync(id);
        if (subject == null) return NotFound();
        return Ok(subject);
    }

    [HttpPost]
    public async Task<ActionResult<SubjectDto>> Create(CreateSubjectDto dto)
    {
        var subject = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = subject.SubjectId }, subject);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SubjectDto>> Update(int id, CreateSubjectDto dto)
    {
        var subject = await _service.UpdateAsync(id, dto);
        if (subject == null) return NotFound();
        return Ok(subject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

}