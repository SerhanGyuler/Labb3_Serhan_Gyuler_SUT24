using System;
using System.Collections.Generic;

namespace Labb3_Serhan_Gyuler_SUT24.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? ClassId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? SocialSecurityNumber { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
