using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class Exam
{
    public int ExamId { get; set; }

    public int SubjectId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Duration { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int TotalQuestions { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Examattempt> Examattempts { get; set; } = new List<Examattempt>();

    public virtual ICollection<Examresult> Examresults { get; set; } = new List<Examresult>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Subject Subject { get; set; } = null!;
}
