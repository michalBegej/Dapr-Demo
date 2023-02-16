namespace Dapr.Demo.Payments.Events.In
{
    public record OrderCreated(int Id, decimal TotalAmount);
}