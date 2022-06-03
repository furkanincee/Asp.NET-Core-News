// .Net 6'da startup.cs kaldýrýlmýþtýr. Servis ve middleware configleri program.cs üzerinden yapýlýr.

// Top level statements: Bu özellikle main fonksiyonunun kullanýlma zorunluluðu kaldýrýlmýþtýr. (C# 9 ile geliyor bu özellik)
// Aslýnda sadece yazýlý hali kaldýrýlmýþtýr arka planda yine senin oraya yazdýðýn kod main içinde ele alýnýr. Bu özellik program.cs dosyasýna hastýr.
// tls genellikle microservices yapýlanmalarýnda kullanýlýr.
// .Net 6'da tls özelliði default olarak gelir. Bak bu sayfada main falan hiçbir þey yok mesela

// WebApplication: Builder nesnesini oluþturur. .Net 5'teki Host sýnýfýnýn karþýlýðýdýr.

var builder = WebApplication.CreateBuilder(args); // .Net 5'deki IHostBuilderin karþýlýðýdýr bu builder nesnesi üzerinden servisler entegre edilir.

// Add services to the container.
builder.Services.AddRazorPages(); // Burda builder üzerinden bir servis eklemesi yapýlmýþ örneðin

var app = builder.Build(); // buildera servisleri ekledikten sonra build ediliyor ve yukarýda eklenen servislerin örneklerini içeren bir IoC Container yapýsýyla uygulama (WepApplication nesnesi) geliyor.
// özetle önce bi builder oluþturuluyor sonra içine servisler ekleniyor en son builder.build() dediðimizde de bu servisleri barýndýran konteyner eklenip
// bir uygulama ayaða kaldýrýlmýþ oluyor. Bence þu an anladýk. Ýnþ okuduðunda da anlarsýn.

// Port: .Net 6 öncesinde uygulamalar default 5001 - 5000 portlarýnda ayaða kalkarken .Net 6da bu port deðiþiklik gösterir.
// Properties klasörünün içinde launchsettings.jsonda portla ilgili biþeyler var.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// En son da burada middlewareler ekleniyor (Use ile baþlayan þeyler middleware'di)
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
