using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoUserBuildingList
{
    public long UbuildingId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? CompanyTokenId { get; set; }

    public string? BuildingTokenId { get; set; }

    public string? BuildingName { get; set; }

    public string? BuildingAddress { get; set; }

    public string? BuildingDay { get; set; }

    public string? BuildingMonth { get; set; }

    public string? BuildingYear { get; set; }

    public string? BuildingDate { get; set; }

    public string? ImageTokenId { get; set; }

    public string? ImageServerUrl { get; set; }

    public bool? IsNew { get; set; }

    public bool? IsVisible { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
