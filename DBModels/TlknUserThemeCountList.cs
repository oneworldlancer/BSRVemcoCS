﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknUserThemeCountList
{
    public long UthemeCountId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public string? ThemeSetId { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? ThemeSetTokenId { get; set; }

    public string? ThemeSetCount { get; set; }

    public string? ThemeCategoryCode { get; set; }

    public string? ThemeCategoryMiniDescription { get; set; }

    public string? ThemeCategoryFullDescription { get; set; }

    public string? ThemeCategoryName { get; set; }

    public string? ThemeCategoryTitle { get; set; }

    public string? ThemeCategoryDescription { get; set; }

    public string? ImageTitle { get; set; }

    public string? ImageCount { get; set; }

    public string? ThemeImageSmallUrl { get; set; }

    public string? ThemeImageMidUrl { get; set; }

    public string? ThemeImageLargeUrl { get; set; }

    public bool? IsCostFree { get; set; }

    public decimal? CostPrice { get; set; }

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
