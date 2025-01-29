using System;
using System.Collections.Generic;

namespace Labb3_Serhan_Gyuler_SUT24.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int? EmployeeId { get; set; }

    public string? ClassName { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
