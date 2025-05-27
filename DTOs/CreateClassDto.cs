namespace MyWebApi.DTOs;

public class CreateClassDto
{
    public string ClassName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}