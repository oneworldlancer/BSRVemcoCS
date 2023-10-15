using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppBuildingReportWordingList
{
    public long AppbuildingReportWordingId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? ApptableTokenId { get; set; }

    public string? ApptableCode { get; set; }

    public string? AppqueryTableTokenId { get; set; }

    public string? AppqueryTableCode { get; set; }

    public string? QueryTableTokenId { get; set; }

    public string? QueryTableName { get; set; }

    public string? QueryTableTitle { get; set; }

    public string? QueryTableText { get; set; }

    public string? QueryTableDescription { get; set; }

    public string? AppinformationTokenId { get; set; }

    public string? AppinformationCode { get; set; }

    public string? ReportWordingTokenId { get; set; }

    public string? ReportWordingCode { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? ReportWordingName { get; set; }

    public string? ReportWordingTitle { get; set; }

    public string? ReportWordingText { get; set; }

    public string? ReportWordingDescription { get; set; }

    public string? InformationName { get; set; }

    public string? InformationTitle { get; set; }

    public string? InformationText { get; set; }

    public string? InformationDescription { get; set; }

    public string? Commentary { get; set; }

    public string? Criterion { get; set; }

    public string? Score { get; set; }

    public string? ScoreOriginal { get; set; }

    public string? ScoreManaged { get; set; }

    public string? ScoreAdjusted { get; set; }

    public string? RiskControlMeasure { get; set; }

    public string? TimeoutYearCount { get; set; }

    public string? TimeoutAppNotification { get; set; }

    public string? TimeoutSystemNotification { get; set; }

    public string? ScoreMinValue { get; set; }

    public string? ScoreMaxValue { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
