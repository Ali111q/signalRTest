# SignalR Client Test Project

This project demonstrates how to test SignalR with an ASP.NET Core backend. It includes the necessary code to connect to a SignalR hub, send notifications, and receive them in real-time.

## Prerequisites

- .NET SDK (6.0 or higher)
- Visual Studio or any compatible IDE
- A running ASP.NET Core SignalR server (backend)

## Setup

### 1. Clone the repository

First, clone this repository to your local machine.

```
git clone <repository-url>
cd <repository-name>
```

### 2. Modify the SignalR Connection URL

In the `Program.cs` file, locate the following section where the SignalR connection is configured:

```
var connection = new HubConnectionBuilder()
.WithUrl("http://<Backend Link>/<SignalR endpoint>", op =>
{
op.Headers.Add("Authorization", "Bearer <UserToken>");
})
.Build();
```

- Replace `<Backend Link>` with the URL of your backend server where the SignalR hub is hosted.
- Replace `<SignalR endpoint>` with the correct SignalR hub endpoint (e.g., `/chatHub`).
- Replace `<UserToken>` with a valid Bearer token for authentication, if needed.

### 3. Build and Run the Project

To test the SignalR client, use the following steps:

1. Open the project in Visual Studio or your preferred IDE.
2. Ensure that your ASP.NET Core backend with SignalR is running.
3. Run the client project.

```
dotnet run
```

### 4. Testing SignalR

- Upon running the project, you will see the message `"Connected to SignalR Hub!"` in the console if the connection is successful.
- The client will listen for incoming notifications via the `ReceiveNotification` method.
- To send a message to the SignalR server, enter a message in the console and press Enter. This message will be sent to the SignalR hub through the `SendNotificationToUser` method.

### 5. Example of Sending a Message

When prompted, enter a message, like so:

```
Send message: Hello, this is a test notification!
```

This will send the message to the SignalR hub and trigger any connected clients to receive the notification.

### 6. Receiving Notifications

If the backend sends a message through SignalR, it will be printed to the console in real-time:

```
Notification Received: Hello, this is a test notification!
```

## Troubleshooting

- Ensure that the SignalR hub is running and accessible from the client.
- Check for any issues with your network or API token.
- If receiving notifications doesn't work, verify that the SignalR `ReceiveNotification` method is correctly set up on the server.

## Conclusion

This simple client demonstrates how to interact with a SignalR hub to send and receive notifications using .NET Core.
