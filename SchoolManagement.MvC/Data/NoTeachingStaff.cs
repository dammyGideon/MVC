﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.MvC.Data;

public partial class NoTeachingStaff
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? Dob { get; set; }
}
