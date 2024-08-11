using System;
using System.Collections.Generic;

namespace LoginaLogout.Models;

public partial class Student
{
    public int RollNo { get; set; }

    public string StudentName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public int Standard { get; set; }
}
