using System;
using System.Collections.Generic;

namespace CourseManagementService.Models.Domains;

public partial class Subject
{
    public Guid Code { get; set; }

    public string Title { get; set; } = null!;

    public int Grade { get; set; }
}
