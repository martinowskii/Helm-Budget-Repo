using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Helm_Budget_System.Data;
using Microsoft.AspNetCore.Identity;
using Helm_Budget_System.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Helm_Budget_SystemContextConnection");;

builder.Services.AddDbContext<Helm_Budget_SystemContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<Helm_SystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Helm_Budget_SystemContext>();;

builder.Services.AddDbContext<Helm_Budget_DbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Helm_Budget_Context>();
    // DbInitializer.Initialize(context);
}*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
