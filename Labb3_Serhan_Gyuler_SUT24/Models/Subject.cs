using System;
using System.Collections.Generic;

namespace Labb3_Serhan_Gyuler_SUT24.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public int? ClassId { get; set; }

    public int? EmployeeId { get; set; }

    public string? SubjectName { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
