using IdentityApp.Web.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Web.Requirements;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// add session service


builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(20);
    opt.Cookie.HttpOnly = true;
    //opt.Cookie.IsEssential = true;
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();


//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
//{
//    opt.ExpireTimeSpan = TimeSpan.FromDays(30);
//    opt.Cookie = new CookieBuilder()
//    {
//        Name = "InveonCookie"
//    };
//});


builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder
    {
        Name = "InveonAppCookie"
    };

    opt.LoginPath = new PathString("/Home/x-Login");
    //opt.LogoutPath = new PathString("/Member/logout");
    opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
});

builder.Services.AddScoped<IAuthorizationHandler, ViolenceRequirementHandler>();
builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("IstanbulPolicy", policy => { policy.RequireClaim("city", "istanbul", "ankara"); });


    configure.AddPolicy("ViolencePolicy",
        policy => { policy.Requirements.Add(new ViolenceRequirement { ThresholdAge = 18 }); });
});

builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromMinutes(30);
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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();