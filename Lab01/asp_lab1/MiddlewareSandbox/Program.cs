var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

int requestCount = 0;
app.Use(async (context, next) =>
{
    requestCount++;
    await next.Invoke();
    await context.Response.WriteAsync($"\nThe amount of processed requests is {requestCount}.");
});

// Middleware 2: Перевірка параметру query string "custom"
app.Use(async (context, next) =>
{
    if (context.Request.Query.ContainsKey("custom"))
    {
        await context.Response.WriteAsync("You’ve hit a custom middleware!");
    }
    else
    {
        await next.Invoke();
    }
});

// Middleware 3: Логування всіх запитів у консоль
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});

// Middleware 4: Перевірка X-API-KEY
const string apiKey = "SECRET123";
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("X-API-KEY", out var key) || key != apiKey)
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Forbidden");
        return; 
    }
    await next.Invoke();
});

app.MapGet("/", () => "Hello from MiddlewareSandbox!");

app.Run();