using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class Examresult
{
    public int ResultId { get; set; }

    public int AttemptId { get; set; }

    public int UserId { get; set; }

    public int ExamId { get; set; }

    public decimal TotalScore { get; set; }

    public DateTime CompletedAt { get; set; }

    public string? Remarks { get; set; }

    public virtual Examattempt Attempt { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
