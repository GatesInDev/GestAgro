using GestAgro.Blazor;
using GestAgro.Blazor.Features.EarlyRegister.Services;

var builder = WebApplication.CreateBuilder(args);

var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrEmpty(apiBaseUrl))
    throw new InvalidOperationException("ApiBaseUrl não foi definida no appsettings.json!");

Action<HttpClient> configureApi = client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
};
builder.Services.AddHttpClient<IUserService, UserService>(configureApi);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();