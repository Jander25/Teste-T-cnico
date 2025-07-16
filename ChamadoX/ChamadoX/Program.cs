using ChamadoX.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Esse Builder � resp�ns�vel para passar nossa string de conex�o para o projeto, aqui tamb�m especificamos qual � o banco que vamos utilizar se slqserver ou postgres e etc.
//Nessa Aplica��o estamos utilizado o banco de dados Postgresql

builder.Services.AddDbContext<AppDbContext>(options => {

    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
