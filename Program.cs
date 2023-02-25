#region Imports
using MongoDB.Driver;
using CLIMATE_DATA_BRAZIL.Controllers;
using CLIMATE_DATA_BRAZIL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
#endregion

#region Instanciate {builder} Variable From WebApplication Class

var builder = WebApplication.CreateBuilder(args);
#endregion

#region Add Services To The Container 

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
#endregion

#region Instanciate {app} Variable With Build() From {builder} variable

var app = builder.Build();
#endregion

#region Configure The HTTP Request Pipeline & Control When Swagger Is In Use

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion