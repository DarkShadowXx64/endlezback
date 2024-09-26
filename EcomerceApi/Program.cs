using Business.Data;
using Business.Logic;
using Business.Logic.AuthLogic;
using Business.Logic.CategoryLogic;
using Business.Logic.CustomerAddress;
using Business.Logic.OrderLogic;
using Business.Logic.OrderStatusLogic;
using Business.Logic.OrderTypeLogic;
using Business.Logic.ProductComment;
using Business.Logic.ProductLogic;
using Business.Logic.ProfileLogic;
using Business.Logic.UserLogic;
using Business.Mappings;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EcomerceApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// TOKEN CONFIGURATION
builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg => {
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = false;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"])
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSingleton<AuthHelpers>();
builder.Services.AddScoped<IAuthHelpers, AuthHelpers>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddTransient<UserResponse>();


builder.Services.AddTransient<AuthResponse>();
builder.Services.AddTransient<ProfileResponse>();
builder.Services.AddTransient<UserResponse>();
builder.Services.AddTransient<CategoryResponse>();
builder.Services.AddTransient<CustomerAddressResponse>();
builder.Services.AddTransient<OrderResponse>();
builder.Services.AddTransient<OrderStatusResponse>();
builder.Services.AddTransient<OrderTypeResponse>();
builder.Services.AddTransient<ProductCommentResponse>();
builder.Services.AddTransient<ProductResponse>();


//builder.Services.AddTransient<PdfService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                      });
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EcomerceDbContext>(x => x.UseSqlServer(connectionString!));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcomerceAPI", Version = "v1" });
});
var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ENABLE JWT
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<AuthorizationMiddleware>();
app.UseCors("AllowAll");
app.Run();

