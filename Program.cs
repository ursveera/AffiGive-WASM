using AffigiveUIBalzor.api;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WASM;
using WASM.api;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

var baseUrl = builder.Configuration["ApiSettings:BaseUrl"];
if (string.IsNullOrWhiteSpace(baseUrl))
    throw new Exception("ApiSettings:BaseUrl is missing");

if (!baseUrl.EndsWith("/"))
    baseUrl += "/";

// ================= LOCAL STORAGE =================
builder.Services.AddBlazoredLocalStorage();

// ================= AUTH =================
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthMessageHandler>();

// 🔹 HttpClient WITHOUT handler (for login only)
builder.Services.AddHttpClient("AuthClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

// 🔹 HttpClient WITH JWT handler (for all APIs)
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
})
.AddHttpMessageHandler<AuthMessageHandler>();

// 🔹 Default HttpClient = API client
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>()
      .CreateClient("ApiClient"));

// ================= API SERVICES =================
builder.Services.AddScoped<IAdminVideoApi, AdminVideoApi>();
builder.Services.AddScoped<IEntryApiGateway, EntryApiGateway>();
builder.Services.AddScoped<IWinnerApiGateway, WinnerApiGateway>();
builder.Services.AddScoped<IAppSettingsApi, AppSettingsApi>();
builder.Services.AddScoped<ITaskApiGateway, TaskApiGateway>();
builder.Services.AddScoped<IGiftApi, GiftApi>();
builder.Services.AddScoped<IUserApi, UserApi>();
builder.Services.AddScoped<IAdminLottieApi, AdminLottieApi>();
builder.Services.AddScoped<ISourceLimitApi, SourceLimitApi>();
builder.Services.AddScoped<IAccountDeleteRequestApi, AccountDeleteRequestApi>();

await builder.Build().RunAsync();
