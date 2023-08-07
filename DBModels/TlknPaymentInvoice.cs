﻿using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class TlknPaymentInvoice
{
    public long PaymentId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? DeviceGlobalId { get; set; }

    public string? AccountType { get; set; }

    public long? PaymentTicketId { get; set; }

    public string? PaymentTokenId { get; set; }

    public string? PaymentStatus { get; set; }

    public string? PaymentTicketStatus { get; set; }

    public int? UserId { get; set; }

    public string? MobileNumberId { get; set; }

    public string? StudioPayment { get; set; }

    public decimal? ModelPayment { get; set; }

    public decimal? JuniorPayment { get; set; }

    public decimal? RoverPayment { get; set; }

    public decimal? TotalAmountPaymentPayout { get; set; }

    public decimal? AdminShaymaa { get; set; }

    public decimal? AdminBear { get; set; }

    public decimal? TotalAmountPaymentAdmin { get; set; }

    public decimal? HostServer { get; set; }

    public decimal? FlashServer { get; set; }

    public decimal? TotalAmountPaymentServer { get; set; }

    public decimal? PayoneerPaymentProcessor { get; set; }

    public decimal? CcbillPaymentProcessor { get; set; }

    public decimal? OtherPaymentProcessor { get; set; }

    public decimal? TotalAmountPaymentProcessor { get; set; }

    public decimal? Tax { get; set; }

    public decimal? OtherTax { get; set; }

    public decimal? TotalAmountPaymentTax { get; set; }

    public decimal? VisaInProcessorPayment { get; set; }

    public decimal? VisaOutProcessorPayment { get; set; }

    public decimal? TotalAmountSiteEarn { get; set; }

    public decimal? TotalAmountSiteSpend { get; set; }

    public decimal? TotalAmountSiteExpense { get; set; }

    public decimal? TotalAmountSiteNetProfit { get; set; }

    public decimal? TotalAmountSiteSave { get; set; }

    public int? TokenAmountTotal { get; set; }

    public string? TokenPricePerOneText { get; set; }

    public string? TokenCostTotalText { get; set; }

    public int? PaymentTicketDay { get; set; }

    public int? PaymentTicketMonth { get; set; }

    public int? PaymentTicketYear { get; set; }

    public decimal? TokenPricePerOneValue { get; set; }

    public decimal? TokenCostTotalValue { get; set; }

    public string? Tax13 { get; set; }

    public string? Tax12 { get; set; }

    public string? Tax11 { get; set; }

    public string? Tax1 { get; set; }

    public int? LoginDay { get; set; }

    public int? LoginMonth { get; set; }

    public int? LoginYear { get; set; }

    public DateTime? LoginDate { get; set; }

    public int? LogoutDay { get; set; }

    public int? LogoutMonth { get; set; }

    public int? LogoutYear { get; set; }

    public DateTime? LogoutDate { get; set; }

    public bool? IsActive { get; set; }

    public string? UploadDateTimeMilliSec { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual TlknPaymentTicket? PaymentTicket { get; set; }
}
