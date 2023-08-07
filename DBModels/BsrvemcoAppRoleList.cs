using System;
using System.Collections.Generic;

namespace BSRVemcoCS.DBModels;

public partial class BsrvemcoAppRoleList
{
    public long UappRoleId { get; set; }

    public Guid RowViewTokenId { get; set; }

    public string? RowDataTokenId { get; set; }

    public string? AccountType { get; set; }

    public string? OwnerUserTokenId { get; set; }

    public string? OwnerMobileNumberTokenId { get; set; }

    public string? AppRoleTokenId { get; set; }

    public string? AppRoleCode { get; set; }

    public string? AppRoleName { get; set; }

    public string? UserRole { get; set; }

    public string? RoleCode { get; set; }

    public string? RoleValue { get; set; }

    public string? RoleName { get; set; }

    public string? RoleTitle { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemUser { get; set; }

    public int? UploadDay { get; set; }

    public int? UploadMonth { get; set; }

    public int? UploadYear { get; set; }

    public DateTime? UploadDate { get; set; }
}
