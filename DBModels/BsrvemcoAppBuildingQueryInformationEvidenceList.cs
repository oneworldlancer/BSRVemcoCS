using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppBuildingQueryInformationEvidenceList
{
    public long AppbuildingQueryInformationEvidenceId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? AppqueryTableTokenId { get; set; }

    public string? AppqueryTableCode { get; set; }

    public string? AppinformationTokenId { get; set; }

    public string? AppinformationCode { get; set; }

    public string? AppqueryInformationTokenId { get; set; }

    public string? AppqueryInformationCode { get; set; }

    public string? QueryInformationTokenId { get; set; }

    public string? EvidenceTokenId { get; set; }

    public string? EvidenceCode { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? EvidenceName { get; set; }

    public string? EvidenceTitle { get; set; }

    public string? EvidenceText { get; set; }

    public string? EvidenceDescription { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
