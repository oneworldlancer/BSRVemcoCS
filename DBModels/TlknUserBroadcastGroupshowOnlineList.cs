﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknUserBroadcastGroupshowOnlineList
{
    public long UgroupShowLiveId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public string? GroupShowId { get; set; }

    public string? GroupShowTicketId { get; set; }

    public string? GroupShowTokenId { get; set; }

    public string? GroupShowVideoId { get; set; }

    public string? GroupShowVideoTokenId { get; set; }

    public string? GroupShowSessionId { get; set; }

    public string? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? MessageTokenId { get; set; }

    public string? Tag { get; set; }

    public string? InviteTag { get; set; }

    public string? GroupShowTag { get; set; }

    public string? GroupShowCode { get; set; }

    public string? GroupShowType { get; set; }

    public string? UserSessionId { get; set; }

    public string? UserType { get; set; }

    public string? UserRole { get; set; }

    public string? ScreenShowStatus { get; set; }

    public int? TodayDay { get; set; }

    public int? TodayMonth { get; set; }

    public int? TodayYear { get; set; }

    public int? TimeCountStart { get; set; }

    public int? TimeCountEnd { get; set; }

    public int? TimeCountConsume { get; set; }

    public int? TimeCountFreeLeft { get; set; }

    public int? TimeCountFreeTotal { get; set; }

    public DateTime? ScreenShowStartTime { get; set; }

    public DateTime? ScreenShowEndTime { get; set; }

    public DateTime? ScreenShowOpenTime { get; set; }

    public DateTime? ScreenShowCloseTime { get; set; }

    public DateTime? ScreenShowInitiateTime { get; set; }

    public DateTime? ScreenShowPendingTime { get; set; }

    public DateTime? ScreenShowSpendTime { get; set; }

    public bool? IsScreenShowOpen { get; set; }

    public bool? IsScreenShowClose { get; set; }

    public bool? IsScreenShowInitiate { get; set; }

    public bool? IsScreenShowPending { get; set; }

    public bool? IsScreenShowStart { get; set; }

    public bool? IsScreenShowEnd { get; set; }

    public bool? IsScreenShowSpend { get; set; }

    public int? ScreenShowTimeSpendHour { get; set; }

    public int? ScreenShowTimeSpendMinute { get; set; }

    public int? ScreenShowTimeSpendSecond { get; set; }

    public int? TimeStartDay { get; set; }

    public int? TimeStartMonth { get; set; }

    public int? TimeStartYear { get; set; }

    public DateTime? TimeStartDate { get; set; }

    public int? TimeEndDay { get; set; }

    public int? TimeEndMonth { get; set; }

    public int? TimeEndYear { get; set; }

    public DateTime? TimeEndDate { get; set; }

    public int? LoginDay { get; set; }

    public int? LoginMonth { get; set; }

    public int? LoginYear { get; set; }

    public DateTime? LoginDate { get; set; }

    public int? LogoutDay { get; set; }

    public int? LogoutMonth { get; set; }

    public int? LogoutYear { get; set; }

    public DateTime? LogoutDate { get; set; }

    public bool? IsOnline { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
