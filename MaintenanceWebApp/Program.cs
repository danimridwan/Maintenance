using MaintenanceWebApp.Data;
using MaintenanceWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using UploadFilesLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

builder.Services.AddScoped<UploadFilesService>();
builder.Services.AddScoped<CRUDService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<UrlStatusService>();
builder.Services.AddScoped<TableService>();
builder.Services.AddScoped<PPMWorkflowService>();
builder.Services.AddScoped<IdentityService>();

//Mailer
builder.Services.Configure<SMTPSettings>(builder.Configuration.GetSection("Mailer"));
builder.Services.AddSingleton<IMailerService, MailerService>();

// Retrieves the connection string named "Default" from the application's configuration.
builder.Services.AddDbContextFactory<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataContext>();


builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    //  Enables role-based authorization and specifies that IdentityRole will be used for managing roles.
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddTransient<DataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

// Enable authentication and authorization in an ASP.NET Core application.
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    seeder.SeedAdminRole();
    await seeder.SeedAdminUser();
}

app.Run();