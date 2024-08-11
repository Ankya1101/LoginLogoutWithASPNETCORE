using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginaLogout.Models;

public partial class Employee
{
    
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Role { get; set; } = null!;
}
