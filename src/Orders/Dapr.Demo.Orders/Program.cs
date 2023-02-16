using Dapr.Client;
using Dapr.Demo.Orders.DTO;

var builder = WebApplication.CreateBuilder(args);

//Register dapr client
builder.Services.AddDaprClient();

var app = builder.Build();

app.MapGet("/", () => "Orders");

app.MapPost("/orders", async (OrderDTO order) =>
{
    using var client = new DaprClientBuilder().Build();
    
    var tasks = order.ProductIds.Select(id =>
    {
        var request = client.CreateInvokeMethodRequest(HttpMethod.Get, "products", $"products/{id}");
        return client.InvokeMethodAsync<ProductDTO>(request);
    }).ToArray();

    var products = await Task.WhenAll(tasks);

    return Results.Ok(new OrderConfirmationDTO(order.Id, products));
});

app.Run();