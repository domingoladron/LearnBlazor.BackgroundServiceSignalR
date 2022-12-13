using System;
using System.Threading.Tasks;

namespace MyBlazorServer.SignalR;

/// <summary>
/// A simple command you want to fire on SignalR
/// </summary>
public interface ISayHelloCommand
{
    Task SayHelloAsync(DateTime syncTriggeredOn);
}