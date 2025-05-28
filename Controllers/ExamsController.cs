using Microsoft.AspNetCore.Mvc;
using MyWebApi.DTOs;
using MyWebApi.Interfaces;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamsController : ControllerBase
{
    private readonly IExamService _service;

    public ExamsController(IExamService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExamDto>>> GetAll()
    {
        var exams = await _service.GetAllAsync();
        return Ok(exams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExamDto>> GetById(int id)
    {
        var exam = await _service.GetByIdAsync(id);
        if (exam == null) return NotFound();
        return Ok(exam);
    }

    [HttpPost]
    public async Task<ActionResult<ExamDto>> Create(CreateExamDto dto)
    {
        var exam = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = exam.ExamId }, exam);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExamDto>> Update(int id, CreateExamDto dto)
    {
        var exam = await _service.UpdateAsync(id, dto);
        if (exam == null) return NotFound();
        return Ok(exam);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}