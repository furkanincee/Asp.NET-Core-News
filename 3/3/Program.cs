var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // baz� middlewareler UseRoutingden �nce �a�r�lmal�d�r. UseRouting manuel olarak �a�r�lmad���nda map fonksiyonlar�yla bir endpoint eklendi�inde otomatik olarak routing middleware'i ba�a eklenecektir. O y�zden bu durumlarda manuel olarak �a��r�p yerini s�ras�n� belirtiyoruz. Biraz kar���k geldi buralar.

app.UseAuthorization();

app.MapRazorPages();

app.Run();
