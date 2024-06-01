using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.Logins;
using DEMO_PuellaSchoolAPP.Repositories.RClassrooms;
using DEMO_PuellaSchoolAPP.Repositories.Roles;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using DEMO_PuellaSchoolAPP.Repositories.Teachers;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IClassroomsRepository, ClassroomsRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();



//Validations
builder.Services.AddScoped<IValidator<StudentModel>, StudentValidator>();

// login
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login"; // Asegúrate de que esta ruta apunte al método de tu controlador que maneja el login.
        options.Cookie.Name = "MolinaTextileSystemAuthCookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.SlidingExpiration = true;
    });

var app = builder.Build();

// no guardar cache
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
