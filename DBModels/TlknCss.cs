using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknCss
{
    public long Cssid { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? Csscode { get; set; }

    public string? Csstext { get; set; }

    public string? Cssvalue { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
