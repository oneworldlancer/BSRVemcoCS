using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknUserSession
{
    public long UsessionId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public string? SessionId { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? UserType { get; set; }

    public string? GuestId { get; set; }

    public bool? IsGuest { get; set; }

    public string? LoginLocationCountryName { get; set; }

    public string? LoginLocationCountryCode { get; set; }

    public string? LoginLocationRegionName { get; set; }

    public string? LoginUserIp { get; set; }

    public string? UserIp { get; set; }

    public string? UserCountry { get; set; }

    public string? UserProvince { get; set; }

    public string? UserState { get; set; }

    public string? UserCity { get; set; }

    public string? UserLoginStatus { get; set; }

    public string? UserMoodStatus { get; set; }

    public string? LoginDay { get; set; }

    public string? LoginMonth { get; set; }

    public string? LoginYear { get; set; }

    public DateTime? LoginDate { get; set; }

    public string? LogoutDay { get; set; }

    public string? LogoutMonth { get; set; }

    public string? LogoutYear { get; set; }

    public DateTime? LogoutDate { get; set; }

    public bool? IsActive { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
