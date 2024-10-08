﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginaLogout.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
