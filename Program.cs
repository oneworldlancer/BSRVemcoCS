using BSRVemcoCS.iApp_Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder ( args );

// Add services to the container.
builder.Services.AddControllersWithViews ( );


#region Identity


builder.Services.AddIdentity<AppCore_IdentityUser , AppCore_IdentityRole> ( options =>
{
    options.User.RequireUniqueEmail = true;
} ).AddEntityFrameworkStores<AppCore_IdentityDBContext> ( );


builder.Services.AddDbContext<AppCore_IdentityDBContext> ( options =>
{
    //the change occurs here.
    //builder.cofiguration and not just configuration
    options.UseSqlServer ( builder.Configuration.GetConnectionString ( "BSRVEMCODB" ) );
} );

builder.Services.Configure<IdentityOptions> ( options =>
{

    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = true;


} );


#endregion









var app = builder.Build ( );

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment ( ) )
{
    app.UseExceptionHandler ( "/Home/Error" );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts ( );
}

app.UseHttpsRedirection ( );
app.UseFileServer ( );      // Shaymaa|| this line of code. 
app.UseDefaultFiles ( );     // Shaymaa|| this line of code.                                  
app.UseStaticFiles ( );

app.UseRouting ( );

app.UseAuthorization ( );



#region Areas


app.MapAreaControllerRoute (
      name: "iWebMembership" ,
      areaName: "iWebMembership" ,
      pattern: "iWebMembership/{controller=Account}/{action=Index}/{id?}"
  );
    
app.MapAreaControllerRoute (
      name: "iWebMember" ,
      areaName: "iWebMember" ,
      pattern: "iWebMember/{controller=Dashboard}/{action=Index}/{id?}"
  );

app.MapControllerRoute (
    name: "areaRoute" ,
    pattern: "{area:exists}/{controller}/{action}/{id?}"
);



#endregion

app.MapControllerRoute (
    name: "default" ,
    pattern: "{controller=Home}/{action=Index}/{id?}" );

app.Run ( );



public partial class Program
{

    public static IConfiguration iConfig;

    public static string Test { get; private set; }

}
