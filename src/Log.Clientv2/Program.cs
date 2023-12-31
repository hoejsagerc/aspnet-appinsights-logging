using BlazorApplicationInsights;
using Log.Clientv2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5146") });
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://app-backend-test-logging.azurewebsites.net") });

// builder.Services.AddBlazorApplicationInsights();

builder.Services.AddApplicationInsightsTelemetry();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
