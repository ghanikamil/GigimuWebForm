using Gigimu.BLL;
using Gigimu.DAL;
using Gigimu.Interface;
using Gigimu.InterfaceBLL;
using GigimuAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddScoped<IPasienDAL, PasienDAL>();
builder.Services.AddScoped<IPasienBLL, PasienBLL>();
builder.Services.AddScoped<IDokterDAL, DokterDAL>();
builder.Services.AddScoped<IDokterBLL, DokterBLL>();
builder.Services.AddScoped<IJadwalDAL, JadwalDAL>();
builder.Services.AddScoped<IJadwalBLL, JadwalBLL>();
builder.Services.AddScoped<IBookingDAL, BookingDAL>();
builder.Services.AddScoped<IBookingBLL, BookingBLL>();

//jwt token
var appSettingsSection = builder.Configuration.GetSection("AppSetting");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
