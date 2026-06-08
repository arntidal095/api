using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);

/// --------------------
/// SERVICES REGISTRATION
/// --------------------

// Controllers (API support)
builder.Services.AddControllers();

// Swagger (API testing UI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// Your WeatherService (Dependency Injection)
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

/// --------------------
/// MIDDLEWARE PIPELINE
/// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP → HTTPS
app.UseHttpsRedirection();

// Enable authorization system (even if not used yet)
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

app.Run();