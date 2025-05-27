using Microsoft.AspNetCore.Mvc;
using MyWebApi.DTOs;
using MyWebApi.Interfaces;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetAll()
        {
            var classes = await _service.GetAllAsync();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetById(int id)
        {
            var classDto = await _service.GetByIdAsync(id);
            if (classDto == null) return NotFound();
            return Ok(classDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClassDto>> Create(CreateClassDto dto)
        {
            var classDto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = classDto.ClassId }, classDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClassDto>> Update(int id, CreateClassDto dto)
        {
            var classDto = await _service.UpdateAsync(id, dto);
            if (classDto == null) return NotFound();
            return Ok(classDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
