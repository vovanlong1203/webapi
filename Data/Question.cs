using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class Question
{
    public int QuestionId { get; set; }

    public int? ExamId { get; set; }

    public int SubjectId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public decimal Points { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Attemptanswer> Attemptanswers { get; set; } = new List<Attemptanswer>();

    public virtual Exam? Exam { get; set; }

    public virtual Subject Subject { get; set; } = null!;
}
