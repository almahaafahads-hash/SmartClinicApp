
using SmartClinicApp.Interfaces;
﻿using SmartClinicApp.Interfaces;
using SmartClinicApp.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();
//<<<<<<< HEAD



// الربط بين الانترفيس والتنفيذ (Dependency Injection)
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();// هذا اللي يشغل نظام المواعيد ف الموقع

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
