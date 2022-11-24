using Microsoft.EntityFrameworkCore;
using MVCStoreData;
using MVCStoreWeb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(config =>
{
    var provider = builder.Configuration.GetValue<string>("DbProvider");
    switch (provider)
    {
        case "Npqsql":
            config.UseNpgsql(
                        builder.Configuration.GetConnectionString("Npgsql"),
                        options => options.MigrationsAssembly("MigrationsSqlServer")
                        );
            break;
        case "SqlServer":
        default:
            config.UseSqlServer(
                        builder.Configuration.GetConnectionString("SqlServer"),
                        options => options.MigrationsAssembly("MigrationsSqlServer")
                         );
            break;
    }
   
});
//----------------------------------------------------------//
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

app.UseMVCStore();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
