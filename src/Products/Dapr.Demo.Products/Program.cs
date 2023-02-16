using Dapr.Demo.Products.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductRepository, InMemoryProductsRepository>();

var app = builder.Build();

app.MapGet("/", () => "Products");

app.MapGet("/products", async (IProductRepository productRepository) => Results.Ok(await productRepository.GetAllAsync()));

app.MapGet("/products/{id}", async (IProductRepository productRepository, int id) =>
    {
        var product = await productRepository.GetAsync(id);
        return product is null ? Results.NotFound() : Results.Ok(product);
    }
);

app.Run();