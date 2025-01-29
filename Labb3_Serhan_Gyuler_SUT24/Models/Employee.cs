using System;
using System.Collections.Generic;

namespace Labb3_Serhan_Gyuler_SUT24.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Profession { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
