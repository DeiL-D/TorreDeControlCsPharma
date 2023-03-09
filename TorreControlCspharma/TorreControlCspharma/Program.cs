using DALcsPharma.Modelo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TorreControlCspharma.Utilities;
using TorreControlCspharma.DTO;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false).AddSessionStateTempDataProvider();
builder.Services.AddDbContext<CspharmaInformacionallContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion"))
    );
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(Option =>
{
    Option.IdleTimeout = TimeSpan.FromMinutes(2);

});
builder.Services.AddAuthentication(options =>
{

    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
{
    config.LoginPath = "/Auth/Login";
    config.AccessDeniedPath = "/Index";
    config.LogoutPath = "/Auth/Logout";
});
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("AuthMessageSenderOptions"));
//builder.Services.AddTransient<CorreoSender>();
builder.Services.AddTransient<EmailSenderr>();
builder.Services.AddScoped<CustomEmailConfirmationTokenProviderr<EmpleadoDTO>>();
builder.Services.AddDefaultIdentity<EmpleadoDTO>(config =>
{
    config.SignIn.RequireConfirmedEmail = true;
    config.Tokens.ProviderMap.Add("CustomEmailConfirmationTokenProviderr",
        new TokenProviderDescriptor(
             typeof(CustomEmailConfirmationTokenProviderr<EmpleadoDTO>)));
    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmationTokenProviderr";
})

.AddEntityFrameworkStores<CspharmaInformacionallContext>()
.AddDefaultTokenProviders();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ANONIMOUS", policy => policy.RequireClaim(ClaimTypes.Role, "0"));
    options.AddPolicy("ADMINONLY", policy => policy.RequireClaim(ClaimTypes.Role, "2"));
    options.AddPolicy("ALLUSERS", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
    options.AddPolicy("ADMINORUSER", policy => policy.RequireAssertion(context =>
       context.User.HasClaim(ClaimTypes.Role, "1") || context.User.HasClaim(ClaimTypes.Role, "2")));
});

builder.Services.ConfigureApplicationCookie(o => {
    o.ExpireTimeSpan = TimeSpan.FromDays(5);
    o.SlidingExpiration = true;

});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseHttpsRedirection();


app.UseSession();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Ha ocurrido un error inesperado vuelva mas tarde.");
    });
});
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
    throw;
}
