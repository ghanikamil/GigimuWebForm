using Gigimu.BLL;
using Gigimu.InterfaceBLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//register session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//register DI
builder.Services.AddScoped<IDokterBLL, DokterBLL>();
builder.Services.AddScoped<IJadwalBLL, JadwalBLL>();
builder.Services.AddScoped<IKonsultasiBLL, KonsultasiBLL>();
builder.Services.AddScoped<IPasienBLL, PasienBLL>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dokters}/{action=Login}");

app.Run();
