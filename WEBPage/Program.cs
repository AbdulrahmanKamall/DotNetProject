using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEBPage.Models;
using WEBPage.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseSqlServer
    ("Data Source=.;Initial Catalog=FinalProject;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
                                                            { option.Password.RequiredLength = 8;
                                                                option.Password.RequireDigit = true;
                                                                option.Password.RequireNonAlphanumeric = false;
                                                                option.Password.RequireUppercase = false;
                                                            }).AddEntityFrameworkStores<ProjectContext>();


builder.Services.AddControllersWithViews();


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
