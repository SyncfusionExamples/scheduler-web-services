using ej2_core_schedule_app.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddNewtonsoftJson(x => { x.SerializerSettings.ContractResolver = new DefaultContractResolver(); })
    .AddNewtonsoftJson(x => x.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat)
    .AddNewtonsoftJson(x => x.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local);
var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\AppData\\ScheduleData.mdf;Integrated Security=True;";
builder.Services.AddDbContext<AppointmentContext>(opts => opts.UseSqlServer(connectionString));

//builder.Services.AddDbContext<AppointmentContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ScheduleDataConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
