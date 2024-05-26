using CompanyStore.App.Services;
using CarStore.App.Data;
using CarStore.App.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//Connection string
var connString = "Data Source=DESKTOP-G9K61T8\\sqlexpress;Initial Catalog=CarCompanyDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
builder.Services
    .AddDbContext<AppDbContext>(o => o.UseSqlServer(connString));

builder.Services.AddScoped<ICarServices, CarsServices>();
builder.Services.AddScoped<ICompanyServices, CompaniesServices>();




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

//app.MapControllerRoute(
//    name: "authentication",
//    pattern: "Authentication/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
