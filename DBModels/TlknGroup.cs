using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknGroup
{
    public long GroupId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public string? GroupCode { get; set; }

    public string? GroupKey { get; set; }

    public int? GroupCodeCount { get; set; }

    public int? GroupCount { get; set; }

    public string? GroupType { get; set; }

    public int? CategoryId { get; set; }

    public int? InviteOwnerUserId { get; set; }

    public int? InviteOwnerMobileNumberId { get; set; }

    public int? UserId { get; set; }

    public int? MobileNumberId { get; set; }

    public int? UserId1 { get; set; }

    public int? MobileNumberId1 { get; set; }

    public int? UserId2 { get; set; }

    public int? MobileNumberId2 { get; set; }

    public int? UserId3 { get; set; }

    public int? MobileNumberId3 { get; set; }

    public int? UserId4 { get; set; }

    public int? MobileNumberId4 { get; set; }

    public int? UserId5 { get; set; }

    public int? MobileNumberId5 { get; set; }

    public string? GroupName { get; set; }

    public string? ImageName { get; set; }

    public string? ImageTitle { get; set; }

    public string? ImageCode { get; set; }

    public string? ImageType { get; set; }

    public string? ImageMimeType { get; set; }

    public string? ImageDescription { get; set; }

    public byte[]? ImageData { get; set; }

    public string? UserType { get; set; }

    public bool? IsActive { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
