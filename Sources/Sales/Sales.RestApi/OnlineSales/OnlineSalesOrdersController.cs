using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.OnlineSale;
using MyCompany.Crm.Sales.Wholesale.OrderPlacement;
using MyCompany.Crm.TechnicalStuff.ProcessModel;
using PlaceOrder = MyCompany.Crm.Sales.OnlineSale.OrderPlacement.PlaceOrder;

namespace MyCompany.Crm.Sales.OnlineSales
{
    [ApiController]
    [Route("rest/online-sales/orders")]
    [ApiVersion("1")]
    public class OnlineSalesOrdersController : ControllerBase
    {
        private readonly CommandHandler<PlaceOrder, OrderPlaced> _placeOrderHandler;
        private readonly OrderDetailsFinder _orderDetailsFinder;

        public OnlineSalesOrdersController(CommandHandler<PlaceOrder, OrderPlaced> placeOrderHandler,
            OrderDetailsFinder orderDetailsFinder)
        {
            _placeOrderHandler = placeOrderHandler;
            _orderDetailsFinder = orderDetailsFinder;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Place(PlaceOrder placeOrder)
        {
            var orderPlaced = await _placeOrderHandler.Handle(placeOrder);
            // Returning value works only if read model is created synchronously.
            // var orderDetails = await _orderDetailsFinder.GetBy(orderPlaced.OrderId);
            return CreatedAtAction("Get", new {id = orderPlaced.OrderId}, null /*orderDetails*/);
        }

        [HttpGet("{id}")]
        public async Task<OrderDetails> Get(Guid id) => await _orderDetailsFinder.GetBy(id);
    }
}