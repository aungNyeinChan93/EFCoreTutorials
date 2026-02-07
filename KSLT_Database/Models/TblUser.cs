using System;
using System.Collections.Generic;

namespace KSLT_Database.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
