using _4.Services;
using _4.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IService, Service>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", [Authorize] () => // Ana dizine bir istek geldi�inde direk i�erideki fonksiyon �al���r. Attribute de kulland�k.
{
    Console.WriteLine("merhaba");
});

// app.MapPost(); bu �ekilde farkl� farkl� get ve post isteklerini kar��layacak API'ler yap�labilir

app.MapPost("/{a}", (string a, IService service) => // route �zerinden bir de�i�ken ald�k ve dependency injection yapt�k. Mimari bunun IoC containerdan geldi�ini kendi anl�yormu�
{ 
    
});

app.Run();

// ***** Mini API ***** //
// Basit i�lemlerde uzun uzun controller action vs olu�turulmas�n� �nlemek i�in pratik olarak mini API kullan�l�r.
// Temel mant��� servis eklendikten sonra middleware k�sm�ndayken API'nin olu�turulup operasyonlar�n yap�lmas�d�r.
