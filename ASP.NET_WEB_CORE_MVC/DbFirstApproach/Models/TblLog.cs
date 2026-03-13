using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models;

public partial class TblLog
{
    public int LogId { get; set; }

    public int StudentId { get; set; }

    public string? Info { get; set; }

    public virtual Student Student { get; set; } = null!;
}
