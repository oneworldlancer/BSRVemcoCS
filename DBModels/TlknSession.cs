﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknSession
{
    public long SessionId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
