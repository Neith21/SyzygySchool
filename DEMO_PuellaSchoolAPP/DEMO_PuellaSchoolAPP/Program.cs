using DEMO_PuellaSchoolAPP.Data;
using DEMO_PuellaSchoolAPP.Models;
using DEMO_PuellaSchoolAPP.Repositories.RClassrooms;
using DEMO_PuellaSchoolAPP.Repositories.RStudents;
using DEMO_PuellaSchoolAPP.Validations;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IClassroomsRepository, ClassroomsRepository>();

//Validations
builder.Services.AddScoped<IValidator<StudentModel>, StudentValidator>();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
