using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoUserBuildingDocumentList
{
    public long UbuildingDocumentId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? CompanyTokenId { get; set; }

    public string? BuildingTokenId { get; set; }

    public string? ApptableTokenId { get; set; }

    public string? ApptableCode { get; set; }

    public string? DocumentTokenId { get; set; }

    public string? AppinformationTokenId { get; set; }

    public string? InformationTokenId { get; set; }

    public string? DocumentCode { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentDescription { get; set; }

    public string? DocumentTitle { get; set; }

    public string? DocumentExtension { get; set; }

    public string? DocumentSize { get; set; }

    public string? DocumentWebUrl { get; set; }

    public string? DocumentLocalPathUrl { get; set; }

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

    public string? TimeoutUserUpload { get; set; }

    public DateTime? TimeoutUserUploadStart { get; set; }

    public string? TimeoutUserUploadStartDay { get; set; }

    public string? TimeoutUserUploadStartMonth { get; set; }

    public string? TimeoutUserUploadStartYear { get; set; }

    public string? TimeoutUserUploadStartText { get; set; }

    public DateTime? TimeoutUserUploadEnd { get; set; }

    public string? TimeoutUserUploadEndDay { get; set; }

    public string? TimeoutUserUploadEndMonth { get; set; }

    public string? TimeoutUserUploadEndYear { get; set; }

    public string? TimeoutUserUploadEndText { get; set; }

    public string? TimeoutUserNotification { get; set; }

    public string? TimeoutSystemNotification { get; set; }

    public DateTime? AlertUserNotification { get; set; }

    public DateTime? AlertSystemNotification { get; set; }

    public bool? IsWithSurvey { get; set; }

    public bool? IsCheckOneTime { get; set; }

    public string? ScoreMinValue { get; set; }

    public string? ScoreMaxValue { get; set; }

    public bool? IsVisited { get; set; }

    public bool? IsViewed { get; set; }

    public bool? IsOpened { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
