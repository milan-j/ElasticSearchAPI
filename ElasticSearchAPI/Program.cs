using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticSearchAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureElasticSearch();
RegisterCustomServices();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();    
    await app.SeedTestDataAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureElasticSearch()
{
    builder.Services.AddSingleton<ElasticsearchClient>(sp =>
    {
        var config = sp.GetRequiredService<IConfiguration>();

        var uri = new Uri(config["Elasticsearch:Uri"] ?? "http://localhost:9200");
        var username = config["Elasticsearch:Username"];
        var password = config["Elasticsearch:Password"];

        var settings = new ElasticsearchClientSettings(uri);

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            settings.Authentication(new BasicAuthentication(username, password));
        }

        if (builder.Environment.IsDevelopment())
        {
            settings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);
            settings.EnableDebugMode();
        }

        return new ElasticsearchClient(settings);
    });
}

void RegisterCustomServices()
{
    builder.Services.AddScoped<IObjectTextService, ObjectTextService>();
    builder.Services.AddScoped<IElasticService, ElasticService>();
    builder.Services.AddScoped<TestDataSeederService>();

}