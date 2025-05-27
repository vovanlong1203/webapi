using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class Attemptanswer
{
    public int AttemptAnswerId { get; set; }

    public int AttemptId { get; set; }

    public int QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public string? UserAnswerText { get; set; }

    public bool? IsCorrect { get; set; }

    public decimal? PointsEarned { get; set; }

    public virtual Answer? Answer { get; set; }

    public virtual Examattempt Attempt { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
