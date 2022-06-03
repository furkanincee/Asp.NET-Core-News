// Bu ders;
// - Service yap�lanmas�
// - IConfiguration
// - ConfigurationManager

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); 
builder.Services.AddHttpContextAccessor(); // IoC Containera ekliyoruz
Console.WriteLine(builder.Configuration["Conf: A"]);

var app = builder.Build();

app.Services.GetService<IHttpContextAccessor>(); // IoC konteynerdan eklenen �eyi �ekiyoruz. �htiya� oldu�unda controllerlar�n i�inden de bunlar� dependency injection ile �a��rabiliriz.

// --> Appsettings.jsona config ekledik.
// ConfigurationManager : Servis entegrasyonlar� esnas�nda bir konfig�rasyon de�erine ihtiyac�m�z varsa bu de�eri bizlere getiren t�rd�r. (builder.Configuration)
// IConfiguration : bu ise middleware'ler �zerinde konfig�rasyonlara eri�ilecekse kullan�l�r. (app.Configuration)

// ConfigurationManager .Net 6'da yeni gelen bir s�n�ft�r. Eklenen json dosyalar�n�n okunmas�n� �ok kolayla�t�rm��t�r.
// conf.json dosyas� olu�turduk �rnek olarak. �imdi onu sisteme entegre edece�iz.
ConfigurationManager cm = new();
cm.AddJsonFile("conf.json");
Console.WriteLine(cm["Anahtar"]);
// bu �ekilde ekledik.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
