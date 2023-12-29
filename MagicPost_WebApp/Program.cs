using FluentValidation.AspNetCore;
using LazZiya.ExpressLocalization;
using MagicPost_ApiIntergration;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Globalization;
using shopCommerce_ApiIntergration;
using Microsoft.AspNetCore.Localization;
using MagicPost_WebApp.LocalizationResources;
using MagicPost__Data.EF;
using Microsoft.EntityFrameworkCore;
using MagicPost__Data.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cultures = new[]
		 {
				new CultureInfo("en"),
				new CultureInfo("vi"),
			};

builder.Services.AddControllersWithViews()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>())
    .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
    {
        // When using all the culture providers, the localization process will
        // check all available culture providers in order to detect the request culture.
        // If the request culture is found it will stop checking and do localization accordingly.
        // If the request culture is not found it will check the next provider by order.
        // If no culture is detected the default culture will be used.
        // Checking order for request culture:
        // 1) RouteSegmentCultureProvider
        //      e.g. http://localhost:1234/tr
        // 2) QueryStringCultureProvider
        //      e.g. http://localhost:1234/?culture=tr
        // 3) CookieCultureProvider
        //      Determines the culture information for a request via the value of a cookie.
        // 4) AcceptedLanguageHeaderRequestCultureProvider
        //      Determines the culture information for a request via the value of the Accept-Language header.
        //      See the browsers language settings
        // Uncomment and set to true to use only route culture provider
        ops.UseAllCultureProviders = false;
        ops.ResourcesPath = "LocalizationResources";
        ops.RequestLocalizationOptions = o =>
        {
            o.SupportedCultures = cultures;
            o.SupportedUICultures = cultures;
            o.DefaultRequestCulture = new RequestCulture("vi");
        };
    });
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			 .AddCookie(options =>
			 {
				 options.LoginPath = "/Account/Login";
				 options.AccessDeniedPath = "/User/Forbidden/";
			 });
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<MagicPostDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MagicPostDb2"));
});
/*
builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<MagicPostDbContext>()
	.AddDefaultTokenProviders();
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();*/

builder.Services.AddTransient<IOrderApiClient, OrderApiClient>();
builder.Services.AddTransient<ISlideApiClient, SlideApiClient>();
builder.Services.AddTransient<IRoleApiClient, RoleApiClient>();
builder.Services.AddTransient<ILogApiClient, LogApiClient>();

builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IDiemGiaoDichApiClient, DiemGiaoDichApiClient>();
builder.Services.AddTransient<IDiemTapKetApiClient, DiemTapKetApiClient>();
builder.Services.AddTransient<ITransferApiClient, TransferApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.meView
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
app.UseSession();
app.UseRequestLocalization();


/*đây là phần url khi mà mình bấm chọn vào product (để xem detail) hay mình bấm vào Category */
app.MapControllerRoute(
					name: "Product Category En",
					pattern: "{culture}/categories/{id}", new
					{
						controller = "Product",
						action = "Category"
					});
app.MapControllerRoute(
  name: "Product Category Vn",
  pattern: "{culture}/danh-muc/{id}", new
  {
	  controller = "Product",
	  action = "Category"
  });
app.MapControllerRoute(
	name: "Product Detail En",
	pattern: "{culture}/products/{id}", new
	{
		controller = "Product",
		action = "Detail"
	});
app.MapControllerRoute(
  name: "Product Detail Vn",
  pattern: "{culture}/san-pham/{id}", new
  {
	  controller = "Product",
	  action = "Detail"
  });
app.MapControllerRoute(

	name: "default",
	pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");

app.Run();
