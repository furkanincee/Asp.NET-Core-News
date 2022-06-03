// Bu ders;
// - Service yapýlanmasý
// - IConfiguration
// - ConfigurationManager

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); 
builder.Services.AddHttpContextAccessor(); // IoC Containera ekliyoruz
Console.WriteLine(builder.Configuration["Conf: A"]);

var app = builder.Build();

app.Services.GetService<IHttpContextAccessor>(); // IoC konteynerdan eklenen þeyi çekiyoruz. Ýhtiyaç olduðunda controllerlarýn içinden de bunlarý dependency injection ile çaðýrabiliriz.

// --> Appsettings.jsona config ekledik.
// ConfigurationManager : Servis entegrasyonlarý esnasýnda bir konfigürasyon deðerine ihtiyacýmýz varsa bu deðeri bizlere getiren türdür. (builder.Configuration)
// IConfiguration : bu ise middleware'ler üzerinde konfigürasyonlara eriþilecekse kullanýlýr. (app.Configuration)

// ConfigurationManager .Net 6'da yeni gelen bir sýnýftýr. Eklenen json dosyalarýnýn okunmasýný çok kolaylaþtýrmýþtýr.
// conf.json dosyasý oluþturduk örnek olarak. Þimdi onu sisteme entegre edeceðiz.
ConfigurationManager cm = new();
cm.AddJsonFile("conf.json");
Console.WriteLine(cm["Anahtar"]);
// bu þekilde ekledik.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
