using MiniNetflix.Components;
using MiniNetflix.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// MongoDB configuration
var connectionString = builder.Configuration["MongoDbSettings:ConnectionString"]
    ?? "mongodb://localhost:27017";
var databaseName = builder.Configuration["MongoDbSettings:DatabaseName"]
    ?? "MiniNetflixDB";

builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
builder.Services.AddSingleton<IMongoDatabase>(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

// Register application services
builder.Services.AddSingleton<MovieService>();
builder.Services.AddSingleton<ActorService>();
builder.Services.AddSingleton<DirectorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
