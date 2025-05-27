namespace MyWebApi.DTOs
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }        
        public string SubjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}