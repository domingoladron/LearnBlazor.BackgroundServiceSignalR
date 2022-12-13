using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MyBlazorServer.SignalR;

namespace MyBlazorServer.BackgroundService;

public class MyBackgroundService : Microsoft.Extensions.Hosting.BackgroundService, IDisposable
{
   
    private readonly IHubContext<MessagingHub, ISayHelloCommand> _messagingHub;
    private Timer? _timer;
    private readonly ILogger _logger;
    public MyBackgroundService(
        IHubContext<MessagingHub, ISayHelloCommand> messagingHub,
        ILogger<MyBackgroundService> logger)
    {
        _logger = logger;
        _messagingHub = messagingHub;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background Service running.");

        _timer = new Timer(FireSignalRAsync, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        await Task.CompletedTask;
    }

    private async void FireSignalRAsync(object? state)
    {
        _logger.LogDebug("Background Service firing hello messaging to main app.");
        await _messagingHub.Clients.All.SayHelloAsync(DateTime.Now);
    }

    public new void Dispose()
    {
        _timer?.Dispose();
    }
}