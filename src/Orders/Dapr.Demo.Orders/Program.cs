using Dapr.Client;
using Dapr.Demo.Orders.Clients;
using Dapr.Demo.Orders.DTO;
using Dapr.Demo.Orders.Events.Out;

const string ProductsAppId = "products";

var builder = WebApplication.CreateBuilder(args);

//Register dapr client
builder.Services.AddDaprClient();

//Register dedicated dapr app client
builder.Services.AddSingleton(new ProductsClient(DaprClient.CreateInvokeHttpClient(ProductsAppId)));
builder.Services.AddSingleton<PaymentClient>();

var app = builder.Build();

app.UseCloudEvents();

app.MapGet("/", () => "Orders");

app.MapPost("/orders", async (ProductsClient productsClient, PaymentClient paymentClient, OrderDTO order) =>
{
    var products = await productsClient.GetProducts(order.ProductIds);

    var total = products.Sum(x => x.Price);
    await paymentClient.Publish(new OrderCreated(order.Id, total));

    return Results.Ok(new OrderConfirmationDTO(order.Id, products));
});

app.Run();