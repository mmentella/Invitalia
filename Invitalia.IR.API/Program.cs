using Invitalia.Core.API.Controllers;
using Invitalia.Core.API.Features;
using Invitalia.Infrastructures.Controllers;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
                })
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Clear();
                    manager.FeatureProviders.Add(new InvitaliaControllerFeatureProvider(typeof(Invitalia.Core.API.Controllers.OperatingUnitController).GetTypeInfo()));
                })
                .AddApplicationPart(typeof(ApplicantController).Assembly)
                .AddApplicationPart(typeof(FundingRequestController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.ToString());
});

builder.Services.AddInMemoryCosmosRepository();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();