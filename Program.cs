using Microsoft.EntityFrameworkCore;
using _413FinalCameronHammond.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<FinalProjectContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:FinalConnection"]);
}
);

builder.Services.AddScoped<IFinalProjectRepository, EFFinalProjectRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



//To Do:
//Clean up Home Controller
//Add Models for the database
//Add Views
//     // Page to list the Stage Names of the potential entertainers
//     // Button to add a new entertainer
//     // Button to view details about an entertainer
//
//Style App with Bootstrap

//Deploy using Azure

//Add Edit and Delete Functionalities