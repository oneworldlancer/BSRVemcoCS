using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppBuildingQueryTableList
{
    public long UbuildingQueryTableId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? ApptableTokenId { get; set; }

    public string? ApptableCode { get; set; }

    public string? AppinformationTokenId { get; set; }

    public string? AppinformationCode { get; set; }

    public string? AppqueryTableTokenId { get; set; }

    public string? AppqueryTableCode { get; set; }

    public string? QueryTableTokenId { get; set; }

    public string? QueryTableName { get; set; }

    public string? QueryTableTitle { get; set; }

    public string? QueryTableText { get; set; }

    public string? QueryTableDescription { get; set; }

    public bool? IsPaging { get; set; }

    public string? PageSize { get; set; }

    public string? PageCount { get; set; }

    public string? PageNumber { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
