using DebraEventApp.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conn = @"Data Source=MSI\SQLCHAMU;User ID=sa;Password=chamu2005;Connect Timeout=30;Encrypt=False;
Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(conn));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPartnerRegisterRepo, PartnerRegisterRepo>();
builder.Services.AddScoped<IAddEventRepo, AddEventRepo>();
builder.Services.AddScoped<IAddTicketRepo, AddTicketRepo>();

// Add services to the container.
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