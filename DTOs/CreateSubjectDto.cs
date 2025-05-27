namespace MyWebApi.DTOs;

public class CreateSubjectDto
{
    public string SubjectName { get; set; } 
    public string? Description { get; set; } = string.Empty;
}
