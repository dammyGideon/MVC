using System;
using System.Collections.Generic;

namespace SchoolManagement.MvC.Data;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Course1 { get; set; } 

    public int? Credit { get; set; } 
}
