using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://<Backend Link>/<SignalR endpoint>", op =>
            {
                op.Headers.Add("Authorization",   "Bearer <UserToken>");
            })
            .Build();

        connection.On<string>("ReceiveNotification", message =>
        {
            Console.WriteLine($"Notification Received: {message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Connected to SignalR Hub!");

        while (true)
        {
            Console.Write("Send message: ");
            var message = Console.ReadLine();
            await connection.InvokeAsync("SendNotificationToUser", Guid.Parse("0194d14a-5769-7520-a3a6-38a8d9d66d13"), message);
        }
    }
}
