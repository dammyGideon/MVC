﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.MvC.Data;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<Entrollment> Entrollments { get; set; } = new List<Entrollment>();
}
