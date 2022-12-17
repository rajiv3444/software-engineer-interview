using FluentValidation;
using FluentValidation.AspNetCore;
using Zip.EmiCalc.Api.Models;
using Zip.EmiCalc.Api.ModelValidators;
using Zip.EmiCalc.BusinessLogic.Payment;

var builder = WebApplication.CreateBuilder(args);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
