

using QrMenu.Data;
using Microsoft.EntityFrameworkCore;
using QrMenu.Models;
//potrebno e da se instalira Microsoft.AspNetCore.Identity.UI ako dava error so AddDefaultIdentity
using Microsoft.AspNetCore.Identity;
using QrMenu.Controllers;

//****DEPENDENCY INJECTION***************************************************************************//
var builder = WebApplication.CreateBuilder(args);
//sekoj dependency injection se kreira pomegju var builder = WebApplication.CreateBuilder(args); var app = builder.Build();
//dependency injection imame so cel da ne se povtara kodot -  primer za konekcija so data baza da ne mora vo sekoj page da ja stavame
// Add services to the container.-dependency injection za da se povrzuvat kontrolerite so views bidejki koristime MVC
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

/*builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer("Data Source=users.db"));*/


var app = builder.Build();



//*****MIDLEWARE**********************************************************************************//
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

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
