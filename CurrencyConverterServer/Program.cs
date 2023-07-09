using CurrencyConverterServer.Converter;
using CurrencyConverterServer.Helper;
using CurrencyConverterServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddSingleton<INumberConverter , NumberConverter>();
builder.Services.AddGrpc();

ConfigureStaticSetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();


void ConfigureStaticSetails()
{
    StaticDetails.DoubleDigits = builder.Configuration.GetSection("Settings")["DoubleDigits"].Split(",");
    StaticDetails.SingleDigits = builder.Configuration.GetSection("Settings")["SingleDigits"].Split(",");
    StaticDetails.GradesForTwo = builder.Configuration.GetSection("Settings")["GradesForTwo"].Split(",");
    StaticDetails.GradesForThree = builder.Configuration.GetSection("Settings")["GradesForThree"].Split(",");
    StaticDetails.AndWord = builder.Configuration.GetSection("Settings")["AndWord"];
    StaticDetails.SingleDollar = builder.Configuration.GetSection("Settings")["SingleDollar"];
    StaticDetails.SingleCent = builder.Configuration.GetSection("Settings")["SingleCent"];
    StaticDetails.PluralDollar = builder.Configuration.GetSection("Settings")["PluralDollar"];
    StaticDetails.PluralCent = builder.Configuration.GetSection("Settings")["PluralCent"];
}