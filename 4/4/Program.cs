using _4.Services;
using _4.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IService, Service>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", [Authorize] () => // Ana dizine bir istek geldiðinde direk içerideki fonksiyon çalýþýr. Attribute de kullandýk.
{
    Console.WriteLine("merhaba");
});

// app.MapPost(); bu þekilde farklý farklý get ve post isteklerini karþýlayacak API'ler yapýlabilir

app.MapPost("/{a}", (string a, IService service) => // route üzerinden bir deðiþken aldýk ve dependency injection yaptýk. Mimari bunun IoC containerdan geldiðini kendi anlýyormuþ
{ 
    
});

app.Run();

// ***** Mini API ***** //
// Basit iþlemlerde uzun uzun controller action vs oluþturulmasýný önlemek için pratik olarak mini API kullanýlýr.
// Temel mantýðý servis eklendikten sonra middleware kýsmýndayken API'nin oluþturulup operasyonlarýn yapýlmasýdýr.
