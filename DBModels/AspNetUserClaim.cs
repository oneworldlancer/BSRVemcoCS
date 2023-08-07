﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual AspNetUser1 User { get; set; } = null!;
}
