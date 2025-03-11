using System;
using System.Collections.Generic;

namespace CourseManagementService.Models.Domains;

public partial class TeacherSubject
{
    public Guid TeacherId { get; set; }

    public Guid SubjectCode { get; set; }

    public virtual Subject SubjectCodeNavigation { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
