using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesale.OrderCreation
{
    [DddAppService]
    public class CreateOrderHandler : CommandHandler<CreateOrder, OrderCreated>
    {
        private readonly Order.Repository _orders;
        private readonly Order.Factory _orderFactory;
        private readonly SalesCrudOperations _crudOperations;
        private readonly OrderEventsOutbox _eventsOutbox;

        public CreateOrderHandler(Order.Repository orders, SalesCrudOperations crudOperations, 
            OrderEventsOutbox eventsOutbox)
        {
            _orders = orders;
            _crudOperations = crudOperations;
            _eventsOutbox = eventsOutbox;
        }

        public async Task<OrderCreated> Handle(CreateOrder command)
        {
            var clientId = command.ClientId;
            var order = await _orderFactory.NewWithMaxTotalCostFor(clientId);
            var orderHeader = new OrderHeader {Id = order.Id.Value, ClientId = clientId.Value};
            await _orders.Save(order);
            await _crudOperations.Create(orderHeader);
            var orderCreated = CreateEventFrom(order, clientId);
            _eventsOutbox.Add(orderCreated);
            return orderCreated;
        }

        private static OrderCreated CreateEventFrom(Order order, ClientId clientId) =>
            new(order.Id.Value, clientId.Value, SalesChannel.Wholesales.ToCode());
    }
}