using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class Examattempt
{
    public int AttemptId { get; set; }

    public int ExamId { get; set; }

    public int UserId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string Status { get; set; } = null!;

    public decimal? Score { get; set; }

    public virtual ICollection<Attemptanswer> Attemptanswers { get; set; } = new List<Attemptanswer>();

    public virtual Exam Exam { get; set; } = null!;

    public virtual ICollection<Examresult> Examresults { get; set; } = new List<Examresult>();

    public virtual User User { get; set; } = null!;
}
