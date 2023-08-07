﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknUserShowYoutubevideo
{
    public long VideoId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? YouTubeVideoId { get; set; }

    public string? YouTubeVideoUrl { get; set; }

    public string? YouTubeVideoIframe { get; set; }

    public string? YouTubeVideoType { get; set; }

    public string? YouTubeFrom { get; set; }

    public string? ShowId { get; set; }

    public string? ShowSessionId { get; set; }

    public string? ShowType { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? UserSessionId { get; set; }

    public string? UserType { get; set; }

    public string? UserRole { get; set; }

    public bool? IsNew { get; set; }

    public bool? IsShareAll { get; set; }

    public int? FromUserId { get; set; }

    public string? FromUserSessionId { get; set; }

    public string? FromUserType { get; set; }

    public string? FromUserRole { get; set; }

    public string? FromUserInviteRole { get; set; }

    public string? ToUserId { get; set; }

    public string? ToUserSessionId { get; set; }

    public string? ToUserType { get; set; }

    public string? ToUserRole { get; set; }

    public bool? IsActive { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
