namespace Dapr.Demo.Orders.Events.Out
{
    public record OrderCreated(int Id, decimal TotalAmount);
}