using ej2_web_api_crud.Data;
using ej2_web_api_crud.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Event>("Events");
    return builder.GetEdmModel();
}

// Add services to the container.

// Resolve CORS errors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrgins", policy =>
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
    options.DefaultPolicyName = "AnyOrgins";
});

// OData batch handling
var batchHandler = new DefaultODataBatchHandler();
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("api", GetEdmModel(), batchHandler).Filter().Select().OrderBy().Expand().SetMaxTop(null).Count());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventsContext>(options => options.UseInMemoryDatabase("EventDb"));

var app = builder.Build();
// Resolve CORS errors
app.UseCors("AnyOrgins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// OData batch handling
app.UseODataBatching();
app.UseHttpsRedirection();
// Routing
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
