using Dapr.Client;
using Dapr.Demo.Orders.Clients;
using Dapr.Demo.Orders.DTO;

const string ProductsAppId = "products";

var builder = WebApplication.CreateBuilder(args);

//Register dapr client
builder.Services.AddDaprClient();

//Register dedicated dapr app client
builder.Services.AddSingleton(new ProductsClient(DaprClient.CreateInvokeHttpClient(ProductsAppId)));

var app = builder.Build();

app.MapGet("/", () => "Orders");

app.MapPost("/orders", async (ProductsClient productsClient, OrderDTO order) =>
{
    var products = await productsClient.GetProducts(order.ProductIds);
    return Results.Ok(new OrderConfirmationDTO(order.Id, products));
});

app.Run();