namespace MyWebApi.DTOs;

public class ClassDto
{
    public int ClassId { get; set; }        
    public string ClassName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
}