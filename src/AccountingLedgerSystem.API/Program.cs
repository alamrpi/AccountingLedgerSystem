using AccountingLedgerSystem.Application.Extensions;
using AccountingLedgerSystem.Application.Features.Queries.Accounts;
using AccountingLedgerSystem.Application.Mappings;
using AccountingLedgerSystem.Infrastructure;
using FluentValidation;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                x.IncludeXmlComments(xmlPath);
            }
            else
            {
                // Log warning but don't create empty file
                Console.WriteLine($"Warning: XML documentation file not found at {xmlPath}. " +
                                 "Enable <GenerateDocumentationFile> in your project file.");
            }
            
        });

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAccountsQueryHandler).Assembly));

        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

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
    }
}