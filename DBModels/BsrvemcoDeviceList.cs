using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoDeviceList
{
    public long UdeviceId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DatabaseServerTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? PlatformOsid { get; set; }

    public string? AccountType { get; set; }

    public string? MembershipType { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? Gcmid { get; set; }

    public string? DeviceId { get; set; }

    public string? AndroidId { get; set; }

    public string? DeviceSoftwareVersion { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsActive { get; set; }

    public int? RemoveDay { get; set; }

    public int? RemoveMonth { get; set; }

    public int? RemoveYear { get; set; }

    public DateTime? RemoveDate { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
