using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using EntityLayer.Entities;
using ServiceLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

// Razor sayfa yenileme i�in
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();
builder.Services.LoadDataAccessLayerExtension(builder.Configuration); //AddScope
builder.Services.LoadServiceLayerExtension(builder.Configuration); //AddScope

builder.Services.AddDbContext<AddDbContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( //DefaultMapCont.
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");



//app.UseEndpoints(endpoints => //AreasForPatient
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Patient}/{action=Index}/{id?}"
//    );
//});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();