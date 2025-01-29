using System;
using System.Collections.Generic;

namespace Labb3_Serhan_Gyuler_SUT24.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? SubjectId { get; set; }

    public int? EmployeeId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly? DateAssigned { get; set; }

    public string? Grades { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
