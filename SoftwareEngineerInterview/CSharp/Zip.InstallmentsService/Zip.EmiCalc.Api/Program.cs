using FluentValidation;
using FluentValidation.AspNetCore;
using Zip.EmiCalc.Api.Middlewares;
//using Zip.EmiCalc.Api.Models;
using Zip.EmiCalc.Api.ModelValidators;
using Zip.EmiCalc.BusinessLogic.Payment;
using Zip.EmiCalc.RequestResponseModels.RequestModels;

var builder = WebApplication.CreateBuilder(args);

// Register logger here
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<PaymentOrderRequest>>();
builder.Services.AddSingleton(typeof(ILogger), logger);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Resister and add Fluent validation with service
builder.Services.AddFluentValidationAutoValidation();

// Dependency Injection - START
builder.Services.AddScoped<IPremiumCalculator, PremiumCalculator>();
builder.Services.AddScoped<IValidator<PaymentOrderRequest>, PaymentOrderRequestValidator>();
// // Dependency Injection - END

var app = builder.Build();

// customer middleware to handle exceptions
app.ConfigureZipCoExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
