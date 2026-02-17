using Microsoft.EntityFrameworkCore;
using SmartClinicApp.Data;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Dependency Injection (Repositories)
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
<<<<<<< HEAD
builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();// هذا اللي يشغل نظام المواعيد ف الموقع

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//تشغيل قاعددة في البرنامج

// إضافة سطر تعريف قاعدة البيانات//
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
=======
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
>>>>>>> 1783c1de7cfc9448cb1e8656a37b01ddb0322b9d

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
