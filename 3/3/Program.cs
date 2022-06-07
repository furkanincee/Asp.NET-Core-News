var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // bazý middlewareler UseRoutingden önce çaðrýlmalýdýr. UseRouting manuel olarak çaðrýlmadýðýnda map fonksiyonlarýyla bir endpoint eklendiðinde otomatik olarak routing middleware'i baþa eklenecektir. O yüzden bu durumlarda manuel olarak çaðýrýp yerini sýrasýný belirtiyoruz. Biraz karýþýk geldi buralar.

app.UseAuthorization();

app.MapRazorPages();

app.Run();
