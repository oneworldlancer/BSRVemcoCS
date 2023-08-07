using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppCmsPageList
{
    public long UappPageId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? AppPageTokenId { get; set; }

    public string? AppPageCode { get; set; }

    public string? AppPageName { get; set; }

    public string? PageTokenId { get; set; }

    public string? PageCode { get; set; }

    public string? PageValue { get; set; }

    public string? PageName { get; set; }

    public string? PageTitle { get; set; }

    public string? PageHtmlcontent { get; set; }

    public string? PageStyleCss { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemUser { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
