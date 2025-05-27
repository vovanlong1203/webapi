using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class Answer
{
    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public string AnswerText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public int Order { get; set; }

    public virtual ICollection<Attemptanswer> Attemptanswers { get; set; } = new List<Attemptanswer>();

    public virtual Question Question { get; set; } = null!;
}
