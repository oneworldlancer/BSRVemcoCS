﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknUserVoiceshowTicket
{
    public long VoiceShowTicketId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? ScreenChatShowId { get; set; }

    public string? VoiceShowId { get; set; }

    public string? VoiceShowSessionId { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
