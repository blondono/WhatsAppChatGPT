using WhatsAppNet.Api.Interfaces;
using WhatsAppNet.Api.Services.WhatsappCloud;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IWhatsappCloudSendMessage, WhatsappCloudSendMessage>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
