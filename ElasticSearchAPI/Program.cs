using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticSearchAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigureElasticSearch();
RegisterCustomServices();
ConfigureJwt();
ConfigureOpenAPI();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    await app.SeedTestDataAsync();
}

app.UseHttpsRedirection();
app.UseAuthentication();
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

void ConfigureJwt()
{
    var jwtSettings = builder.Configuration.GetSection("Jwt");
    var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

    builder.Services.AddAuthorization();
}

void ConfigureOpenAPI()
{
    builder.Services.AddOpenApi(options =>
    {
        options.AddDocumentTransformer((document, context, cancellationToken) =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme.ToLower(),
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insert JWT token below..."
            };

            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>
            {
                { JwtBearerDefaults.AuthenticationScheme, securityScheme }
            };

            document.Security =
            [
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, document),
                        new List<string>()
                    }
                }
            ];

            return Task.CompletedTask;
        });
    });
}

void RegisterCustomServices()
{
    builder.Services.AddScoped<IObjectTextService, ObjectTextService>();
    builder.Services.AddScoped<IElasticService, ElasticService>();
    builder.Services.AddScoped<TestDataSeederService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
}