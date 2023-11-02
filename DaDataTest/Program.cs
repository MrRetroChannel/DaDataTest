using DaDataTest.Clients;
using DaDataTest.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DaDataClientConfig>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddLogging();

builder.Services.AddHttpClient<DaDataClient>((serviceProvider, client) =>
{
    var config = serviceProvider.GetRequiredService<DaDataClientConfig>();
    client.BaseAddress = config.BaseUrl;

    foreach (var (key, val) in config.Headers)
        client.DefaultRequestHeaders.Add(key, val);

    client.DefaultRequestHeaders.Add("Authorization", "Token " + config.ApiKey);
    client.DefaultRequestHeaders.Add("X-Secret", config.SecretToken);
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
