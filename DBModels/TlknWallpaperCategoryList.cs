﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknWallpaperCategoryList
{
    public long UwallpaperCategoryId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? WallpaperCategoryTokenId { get; set; }

    public string? WallpaperCategoryCode { get; set; }

    public string? WallpaperCategoryMiniDescription { get; set; }

    public string? WallpaperCategoryFullDescription { get; set; }

    public string? WallpaperCategoryName { get; set; }

    public string? WallpaperCategoryTitle { get; set; }

    public string? WallpaperCategoryDescription { get; set; }

    public string? ImageTitle { get; set; }

    public string? ImageCount { get; set; }

    public string? WallpaperImageSmallUrl { get; set; }

    public string? WallpaperImageMidUrl { get; set; }

    public string? WallpaperImageLargeUrl { get; set; }

    public int? CategoryOrder { get; set; }

    public bool? IsGallery { get; set; }

    public bool? IsSystem { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsPersonal { get; set; }

    public string? Password { get; set; }

    public bool? IsDefault { get; set; }

    public bool? IsAvatar { get; set; }

    public bool? IsUpload { get; set; }

    public bool? IsNew { get; set; }

    public bool? IsView { get; set; }

    public bool? IsRecent { get; set; }

    public string? ActiveStatus { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
