﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknUserInviteshowLogin
{
    public long InviteLoginId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? UserId { get; set; }

    public string? TlknUserId { get; set; }

    public string? UserSessionId { get; set; }

    public string? UserType { get; set; }

    public string? InviteShowId { get; set; }

    public string? InviteShowCode { get; set; }

    public string? InviteShowStatus { get; set; }

    public string? GroupShowId { get; set; }

    public string? GroupShowTicketId { get; set; }

    public string? GroupShowInviteId { get; set; }

    public string? GroupShowInviteType { get; set; }

    public bool? IsNotificationShow { get; set; }

    public DateTime? NotificationStart { get; set; }

    public DateTime? NotificationReset { get; set; }

    public string? EventSoundCode { get; set; }

    public string? EventSoundText { get; set; }

    public string? EventSoundValue { get; set; }

    public string? FromUserId { get; set; }

    public string? FromTlknUserId { get; set; }

    public string? FromUserSessionId { get; set; }

    public string? FromUserType { get; set; }

    public string? FromUserRole { get; set; }

    public string? ToUserId { get; set; }

    public string? ToTlknUserId { get; set; }

    public string? ToUserSessionId { get; set; }

    public string? ToUserType { get; set; }

    public string? ToUserRole { get; set; }

    public bool? IsOnline { get; set; }

    public bool? IsActive { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
