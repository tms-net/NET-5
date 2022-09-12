using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Add Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => options.LoginPath = "/home/login")
    .AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // https://localhost:7064/

app.MapGet("/claims", async context =>
{
    ClaimsPrincipal principal = context.User as ClaimsPrincipal;

    if (principal != null)
    {
        foreach (Claim claim in principal.Claims)
        {
            await context.Response.WriteAsync(
                "CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "\n");
        }
    }
});

//app.MapFallbackToFile("index.html");

app.Run();
