using System;
using System.Collections.Generic;

namespace ASPCoreWebAPI.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Session { get; set; } = null!;
}
