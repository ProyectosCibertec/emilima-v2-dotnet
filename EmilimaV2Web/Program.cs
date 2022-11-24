using EmilimaV2Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.ExpireTimeSpan = TimeSpan.FromDays(1);
        o.SlidingExpiration = true;
        o.AccessDeniedPath = "/Error/Error401";
        o.LoginPath = "/Login/";
        o.LogoutPath = "/Logout/";
    });

builder.Services.AddDbContext<EmilimaContext>(o =>
 {
     o.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
 });

// builder.Services.AddDbContext<EmilimaContext>(options =>
//         options.UseSqlServer("name=ConnectionStrings:Connection"));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error/Error404");

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
