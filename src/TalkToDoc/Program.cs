using TalkToDoc.Client.Shared;
using TalkToDoc.Components;
using TalkToDoc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddScoped<IWatsonDiscoveryService, WatsonDiscoveryService>();
builder.Services.AddAntiforgery();

builder.Services.AddHttpClient();

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.Configure<WatsonDiscoveryConfig>(builder.Configuration.GetSection(WatsonDiscoveryConfig.Name));
builder.Services.Configure<WatsonxAssistantConfig>(builder.Configuration.GetSection(WatsonxAssistantConfig.Name));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TalkToDoc.Client._Imports).Assembly);

app.Run();
