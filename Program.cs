var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();


// app.MapGet("/date", () =>
// {
//     return DateOnly.FromDateTime(DateTime.Now);
// })
// .WithName("GetDate");


app.MapControllers();
app.Run();

