﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoUserBuildingInformationList
{
    public long UbuildingInformationId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? CompanyTokenId { get; set; }

    public string? BuildingTokenId { get; set; }

    public string? ApptableTokenId { get; set; }

    public string? ApptableCode { get; set; }

    public string? AppinformationTokenId { get; set; }

    public string? AppinformationCode { get; set; }

    public string? InformationTokenId { get; set; }

    public string? AppqueryTableTokenId { get; set; }

    public string? AppqueryTableCode { get; set; }

    public string? QueryTableTokenId { get; set; }

    public string? AppqueryInformationTokenId { get; set; }

    public string? QueryInformationTokenId { get; set; }

    public string? QueryTableName { get; set; }

    public string? QueryTableTitle { get; set; }

    public string? QueryTableText { get; set; }

    public string? QueryTableDescription { get; set; }

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

    public string? Score { get; set; }

    public string? ScoreOriginal { get; set; }

    public string? ScoreManaged { get; set; }

    public string? ScoreAdjusted { get; set; }

    public string? RiskControlMeasure { get; set; }

    public string? DocumentCount { get; set; }

    public string? InformationScore { get; set; }

    public string? QuestionCode { get; set; }

    public string? QuestionType { get; set; }

    public string? QuestionText { get; set; }

    public string? QuestionDescription { get; set; }

    public bool? IsAnswered { get; set; }

    public string? AnswerCode { get; set; }

    public string? AnswerType { get; set; }

    public string? AnswerText { get; set; }

    public string? AnswerDescription { get; set; }

    public string? TimeoutYearCount { get; set; }

    public string? TimeoutAppNotification { get; set; }

    public string? TimeoutUserUpload { get; set; }

    public DateTime? TimeoutUserUploadStart { get; set; }

    public DateTime? TimeoutUserUploadEnd { get; set; }

    public string? TimeoutUserNotification { get; set; }

    public string? TimeoutSystemNotification { get; set; }

    public string? ImageTokenId { get; set; }

    public bool? IsPaging { get; set; }

    public string? PageSize { get; set; }

    public string? PageCount { get; set; }

    public string? PageNumber { get; set; }

    public bool? IsVisited { get; set; }

    public bool? IsViewed { get; set; }

    public bool? IsOpened { get; set; }

    public bool? IsVisible { get; set; }

    public string? ScoreMinValue { get; set; }

    public string? ScoreMaxValue { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
