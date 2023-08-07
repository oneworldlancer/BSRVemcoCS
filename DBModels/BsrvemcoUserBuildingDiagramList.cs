using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoUserBuildingDiagramList
{
    public long UbuildingDiagramId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? CompanyTokenId { get; set; }

    public string? BuildingTokenId { get; set; }

    public string? ApptableTokenId1 { get; set; }

    public string? ApptableCode1 { get; set; }

    public string? AppTableTokenId1scoreTotal { get; set; }

    public string? ApptableTokenId2 { get; set; }

    public string? ApptableCode2 { get; set; }

    public string? AppTableTokenId2scoreTotal { get; set; }

    public string? ApptableTokenId3 { get; set; }

    public string? ApptableCode3 { get; set; }

    public string? AppTableTokenId3scoreTotal { get; set; }

    public string? ApptableTokenId4 { get; set; }

    public string? ApptableCode4 { get; set; }

    public string? AppTableTokenId4scoreTotal { get; set; }

    public string? AppTableTokenId4scoreAverage { get; set; }

    public string? ScoreTotalQuality { get; set; }

    public string? ScoreRiskAverage { get; set; }

    public string? ApptableTokenId7 { get; set; }

    public string? ApptableTokenId6 { get; set; }

    public string? ApptableTokenId5 { get; set; }

    public string? BuildingName { get; set; }

    public string? BuildingAddress { get; set; }

    public string? BuildingDay { get; set; }

    public string? BuildingMonth { get; set; }

    public string? BuildingYear { get; set; }

    public string? BuildingDate { get; set; }

    public string? ImageTokenId { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
