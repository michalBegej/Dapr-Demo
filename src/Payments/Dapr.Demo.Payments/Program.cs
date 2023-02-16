using Dapr;
using Dapr.Demo.Payments.Events.In;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Dapr as serialization uses Cloud events
app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapGet("/", () => "Payments");

app.MapPost("events/orders", [Topic("pubsub", "order_created")](OrderCreated orderCreated) =>
{
    Console.WriteLine($"Starting payment for order: {orderCreated.Id}, total amount: {orderCreated.TotalAmount}");

    return Results.Ok();
});

app.Run();