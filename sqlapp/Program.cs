using sqlapp.Services;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://appconfig7021.azconfig.io;Id=kc9V-l4-s0:LVdRohgMge88GbZOAiSQ;Secret=sfku2nDhAp8JV2LiLHCJaH9WGRzzv7aC/gk8v+ieDRU=";

builder.Host.ConfigureAppConfiguration(builder =>
{
    //Connect to your App Config Store using the connection string
    builder.AddAzureAppConfiguration(options =>
                    options.Connect(connectionString).UseFeatureFlags());
});


builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
