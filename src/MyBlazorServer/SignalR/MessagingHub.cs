using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MyBlazorServer.SignalR;

public class MessagingHub : Hub<ISayHelloCommand>
{
    public async Task SayHelloAsync(DateTime dateTime)
    {
        await Clients.All.SayHelloAsync(dateTime);
    }
}