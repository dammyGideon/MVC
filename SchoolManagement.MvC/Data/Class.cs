using System;
using System.Collections.Generic;

namespace SchoolManagement.MvC.Data;

public partial class Class
{
    public int Id { get; set; }

    public int? LecturerId { get; set; }

    public int? CourseId { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Entrollment> Entrollments { get; set; } = new List<Entrollment>();

    public virtual Lecturer? Lecturer { get; set; }
}
