// .Net 6'da startup.cs kald�r�lm��t�r. Servis ve middleware configleri program.cs �zerinden yap�l�r.

// Top level statements: Bu �zellikle main fonksiyonunun kullan�lma zorunlulu�u kald�r�lm��t�r. (C# 9 ile geliyor bu �zellik)
// Asl�nda sadece yaz�l� hali kald�r�lm��t�r arka planda yine senin oraya yazd���n kod main i�inde ele al�n�r. Bu �zellik program.cs dosyas�na hast�r.
// tls genellikle microservices yap�lanmalar�nda kullan�l�r.
// .Net 6'da tls �zelli�i default olarak gelir. Bak bu sayfada main falan hi�bir �ey yok mesela

// WebApplication: Builder nesnesini olu�turur. .Net 5'teki Host s�n�f�n�n kar��l���d�r.

var builder = WebApplication.CreateBuilder(args); // .Net 5'deki IHostBuilderin kar��l���d�r bu builder nesnesi �zerinden servisler entegre edilir.

// Add services to the container.
builder.Services.AddRazorPages(); // Burda builder �zerinden bir servis eklemesi yap�lm�� �rne�in

var app = builder.Build(); // buildera servisleri ekledikten sonra build ediliyor ve yukar�da eklenen servislerin �rneklerini i�eren bir IoC Container yap�s�yla uygulama (WepApplication nesnesi) geliyor.
// �zetle �nce bi builder olu�turuluyor sonra i�ine servisler ekleniyor en son builder.build() dedi�imizde de bu servisleri bar�nd�ran konteyner eklenip
// bir uygulama aya�a kald�r�lm�� oluyor. Bence �u an anlad�k. �n� okudu�unda da anlars�n.

// Port: .Net 6 �ncesinde uygulamalar default 5001 - 5000 portlar�nda aya�a kalkarken .Net 6da bu port de�i�iklik g�sterir.
// Properties klas�r�n�n i�inde launchsettings.jsonda portla ilgili bi�eyler var.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// En son da burada middlewareler ekleniyor (Use ile ba�layan �eyler middleware'di)
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
