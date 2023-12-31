using FluentValidation.AspNetCore;
using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost_Application.DiemGiaoDichs;
using MagicPost_Application.DiemTapKets;
using MagicPost_Application.Orders;
using MagicPost_Application.Transfer;
using MagicPost_Application.System.Roles;
using MagicPost_Application.System.Users;
using MagicPost_Application.Utilities.Slides;
using MagicPost_ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MagicPost_Application.Logs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();

builder.Services.AddDbContext<MagicPostDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("MagicPostDb2"));
});

builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<MagicPostDbContext>()
	.AddDefaultTokenProviders();

// ---------------------------------------------------------------------------Declare DI------------------------------------------------

builder.Services.AddTransient<IOrderService, OrderService>();
/*
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IStorageService, FileStorageService>();*/
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<ISlideService, SlideService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IDiemGiaoDichService, DiemGiaoDichService>();
builder.Services.AddTransient<IDiemTapKetService, DiemTapKetService>();
builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<ILogService, LogService>();

/*
builder.Services.AddTransient<ISlideService, SlideService>();*/


// ----------------------------------------------------------------------------Cau hinh cho buider------------------------------------
builder.Services.AddControllers()
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Shopping Commerce", Version = "v1" });

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				  {
					{
					  new OpenApiSecurityScheme
					  {
						Reference = new OpenApiReference
						  {
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						  },
						  Scheme = "oauth2",
						  Name = "Bearer",
						  In = ParameterLocation.Header,
						},
						new List<string>()
		}
					});

});
string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
		.AddJwtBearer(options =>
		{
			options.RequireHttpsMetadata = false;
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidateIssuer = true,
				ValidIssuer = issuer,
				ValidateAudience = true,
				ValidAudience = issuer,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ClockSkew = System.TimeSpan.Zero,
				IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
			};
		});

builder.Services.AddMvc(options =>
{
	options.SuppressAsyncSuffixInActionNames = false;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();