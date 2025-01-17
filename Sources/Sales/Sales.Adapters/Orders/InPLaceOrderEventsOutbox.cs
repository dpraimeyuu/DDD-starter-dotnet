using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Outbox;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Orders
{
    public class InPLaceOrderEventsOutbox : InPlaceTransactionalOutbox<OrderEvent>, OrderEventsOutbox
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor",
            Justification = "Required by DI container")]
        public InPLaceOrderEventsOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
            MessageTypes messageTypes)
            : base(outboxes, repository, messageTypes) { }

        protected override string GetPartitionKeyFor(OrderEvent message) => message.OrderId.ToString("N");
    }
}