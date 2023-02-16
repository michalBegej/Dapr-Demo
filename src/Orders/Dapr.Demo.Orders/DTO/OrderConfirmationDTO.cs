namespace Dapr.Demo.Orders.DTO
{
    public record OrderConfirmationDTO(int OrderId, ProductDTO[] Products);
}