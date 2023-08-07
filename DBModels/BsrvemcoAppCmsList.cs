using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppCmsList
{
    public long UappCmsid { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? AppCmstokenId { get; set; }

    public string? AppCmscode { get; set; }

    public string? AppCmsname { get; set; }

    public string? CmstokenId { get; set; }

    public string? Cmscode { get; set; }

    public string? Cmsvalue { get; set; }

    public string? Cmsname { get; set; }

    public string? Cmstitle { get; set; }

    public string? Cmshtmlcontent { get; set; }

    public string? CmsstyleCss { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemUser { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
