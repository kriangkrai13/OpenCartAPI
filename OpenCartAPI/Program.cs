using System.Diagnostics;
using OpenCart.DatabaseSpecific;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
var builder = WebApplication.CreateBuilder(args);

//connect database
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string is not found");
}

RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
    c => c.SetTraceLevel(TraceLevel.Verbose)
          .AddDbProviderFactory(typeof(Microsoft.Data.SqlClient.SqlClientFactory))
);
//add service connection database
builder.Services.AddSingleton<DataAccessAdapter>(new DataAccessAdapter(connectionString));

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

app.Run();
