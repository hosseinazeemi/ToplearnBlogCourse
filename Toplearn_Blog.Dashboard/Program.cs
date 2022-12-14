using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toplearn_Blog.Dashboard;
using Toplearn_Blog.Dashboard.Repositories.Admin;
using Toplearn_Blog.Dashboard.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
string apiUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
builder.Services.AddScoped(sp => new HttpClient
{ BaseAddress = new Uri(apiUrl) });

builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IAdminRepoService , AdminRepoService>();
builder.Services.AddAntDesign();
await builder.Build().RunAsync();
