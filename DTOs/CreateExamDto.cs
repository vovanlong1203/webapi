namespace MyWebApi.DTOs;

public class CreateExamDto
{
    public int SubjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Duration { get; set; } // Duration in minutes
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int TotalQuestions { get; set; }
    public int CreatedBy { get; set; } // User ID of the creator
}