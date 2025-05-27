using System;
using System.Collections.Generic;

namespace MyWebApi.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? ClassId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Examattempt> Examattempts { get; set; } = new List<Examattempt>();

    public virtual ICollection<Examresult> Examresults { get; set; } = new List<Examresult>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
