using XBank.NotificationService.EventHandlers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<TransactionCreatedEventHandler>();

var app = builder.Build();
app.Run();
