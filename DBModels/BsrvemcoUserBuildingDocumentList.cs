﻿using System;
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

    public string? TimeoutYearCount { get; set; }

    public string? TimeoutAppNotification { get; set; }

    public string? TimeoutUserUpload { get; set; }

    public DateTime? TimeoutUserUploadStart { get; set; }

    public DateTime? TimeoutUserUploadEnd { get; set; }

    public string? TimeoutUserNotification { get; set; }

    public string? TimeoutSystemNotification { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
