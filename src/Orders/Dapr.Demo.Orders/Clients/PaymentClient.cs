using Dapr.Client;
using Dapr.Demo.Orders.Events.Out;

namespace Dapr.Demo.Orders.Clients
{
    public class PaymentClient
    {
        private readonly DaprClient _client;

        public PaymentClient(DaprClient client)
        {
            _client = client;
        }

        public async Task Publish(OrderCreated orderCreated)
        {
            await _client.PublishEventAsync("pubsub", "order_created", orderCreated);
        }
    }
}