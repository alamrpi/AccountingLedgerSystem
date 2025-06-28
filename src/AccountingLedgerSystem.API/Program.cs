using AccountingLedgerSystem.API.Exceptions;
using AccountingLedgerSystem.Application.Extensions;
using AccountingLedgerSystem.Application.Features.Queries.Accounts;
using AccountingLedgerSystem.Application.Mappings;
using AccountingLedgerSystem.Application.Validators;
using AccountingLedgerSystem.Infrastructure;
using AccountingLedgerSystem.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAccountsQueryHandler).Assembly));
        builder.Services.AddValidatorsFromAssembly(typeof(JournalEntryValidator).Assembly);
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails(); // For automatic ProblemDetails

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");
        app.MapControllers();

        app.Run();
    }
}