using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using ProyectoPREP.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
Action<SqlServerDbContextOptionsBuilder>? GetConnectionString(string v)
{
    throw new NotImplementedException();
}

builder.Services.AddDbContext<DbPrepContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionPREP"));
});


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
    pattern: "{controller=DatosGenerales}/{action=DatosGeneralesPorElegibilidad}/{id?}");

app.Run();


//services.AddControllersWithViews()
//               .AddNewtonsoftJson(options =>
//               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//           );


//Usuario:  402-4116042-9	

//Clave: 12345
//identificador: C
//IdDeptoDepend :1641


//Server = 190.94.103.222,3342
//id = snsintranet;
//password = Oblgg573uow4yZE8dt5L
