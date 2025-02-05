using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5283/signalR?userId=0194d14a-5769-7520-a3a6-38a8d9d66d13", op =>
            {
                op.Headers.Add("Authorization",   "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJiOWIyYjJkMS1hOGQwLTQ5NjgtOTNjYy03MTgyZTMzZWZjY2UiLCJpZCI6ImI5YjJiMmQxLWE4ZDAtNDk2OC05M2NjLTcxODJlMzNlZmNjZSIsInJvbGUiOiJBZG1pbiIsIlJvbGUiOiJBZG1pbiIsIm5iZiI6MTczODc1MDY2MiwiZXhwIjoxNzQxMzQyNjYyLCJpYXQiOjE3Mzg3NTA2NjJ9.6egfC03VF1mRv545_slZdSCmBU_bTMpHvfPgF6H8csEViInZAzYScVDdX7Rz-ZRsi6_DeEGEpqUqBQm2-3lkfw");
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
