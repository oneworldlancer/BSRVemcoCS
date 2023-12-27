using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppBuildingInformationList
{
    public long AppbuildingInformationId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? ApptableTokenId { get; set; }

    public string? ApptableCode { get; set; }

    public string? AppinformationTokenId { get; set; }

    public string? AppinformationCode { get; set; }

    public string? AppqueryTableTokenId { get; set; }

    public string? AppqueryTableCode { get; set; }

    public string? AppqueryInformationTokenId { get; set; }

    public string? QueryTableTokenId { get; set; }

    public string? QueryTableName { get; set; }

    public string? QueryTableTitle { get; set; }

    public string? QueryTableText { get; set; }

    public string? QueryTableDescription { get; set; }

    public bool? IsPaging { get; set; }

    public string? PageSize { get; set; }

    public string? PageCount { get; set; }

    public string? PageNumber { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? InformationCode { get; set; }

    public string? InformationType { get; set; }

    public string? InformationName { get; set; }

    public string? InformationTitle { get; set; }

    public string? InformationText { get; set; }

    public string? InformationDescription { get; set; }

    public string? InformationTitleSystem { get; set; }

    public string? InformationTextSystem { get; set; }

    public string? InformationDescriptionSystem { get; set; }

    public string? InformationTitleUser { get; set; }

    public string? InformationTextUser { get; set; }

    public string? InformationDescriptionUser { get; set; }

    public string? Commentary { get; set; }

    public string? Criterion { get; set; }

    public string? RiskCode { get; set; }

    public string? RiskOption { get; set; }

    public string? RiskText { get; set; }

    public string? RiskDescription { get; set; }

    public string? Score { get; set; }

    public string? ScoreOriginal { get; set; }

    public string? ScoreManaged { get; set; }

    public string? ScoreAdjusted { get; set; }

    public string? RiskControlMeasure { get; set; }

    public string? QuestionCode { get; set; }

    public string? QuestionType { get; set; }

    public string? QuestionText { get; set; }

    public string? QuestionDescription { get; set; }

    public bool? IsAnswered { get; set; }

    public string? AnswerCode { get; set; }

    public string? AnswerType { get; set; }

    public string? AnswerText { get; set; }

    public string? AnswerDescription { get; set; }

    public string? TimeframeYearCount { get; set; }

    public string? TimeframeMonthCount { get; set; }

    public string? TimeframeAppNotification { get; set; }

    public string? TimeframeSystemNotification { get; set; }

    public string? TimeframeUserNotification { get; set; }

    public string? TimeoutYearCount { get; set; }

    public string? TimeoutAppNotification { get; set; }

    public string? TimeoutSystemNotification { get; set; }

    public DateTime? AlertUserNotification { get; set; }

    public DateTime? AlertSystemNotification { get; set; }

    public bool? IsWithSurvey { get; set; }

    public bool? IsCheckOneTime { get; set; }

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

    public string? RiskOptiona { get; set; }

    public string? RoskTexta { get; set; }

    public string? RiskDescriptiona { get; set; }
}
