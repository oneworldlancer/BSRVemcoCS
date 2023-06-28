var builder = WebApplication.CreateBuilder ( args );

// Add services to the container.
builder.Services.AddControllersWithViews ( );

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
