using BookStore1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options => {

    options.Cookie.Name = "CookieAuth";
    }
);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasToBeAdmin", 
        policy => policy.RequireClaim("AccountType", "Admin")
        );
    options.AddPolicy("HasToBeSignedIn",
       policy => policy.RequireClaim("AccountType")
       );
}
);
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
    pattern: "{controller=Home}/{action=HomeView}/{id?}");

app.Run();
