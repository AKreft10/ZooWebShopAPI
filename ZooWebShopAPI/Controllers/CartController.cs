using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.Feautures.Carts.Queries;
using ZooWebShopAPI.Feautures.Emails.Commands;
using ZooWebShopAPI.Feautures.Invoices.Commands;
using ZooWebShopAPI.UserContext.Queries;

namespace ZooWebShopAPI.Controllers
{
    [ApiController]
    [Route("cart")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueryDataAccess _dataAccess;

        public CartController(IMediator mediator, IQueryDataAccess dataAccess)
        {
            _mediator = mediator;
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var cartItems = await _mediator.Send(new GetCartItemsQuery());
            return Ok(cartItems);
        }

        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddItemToCart([FromBody] AddProductToCartDto dto)
        {
            await _mediator.Send(new AddProductToCartCommand(dto));
            return Ok();
        }

        [HttpPost]
        [Route("remove-item/{itemId}")]
        public async Task<IActionResult> RemoveItemFromCart([FromRoute] int itemId)
        {
            await _mediator.Send(new RemoveProductFromCartCommand(itemId, await GetUserId()));
            return Ok("Item has been successfully removed from the cart.");
        }

        [HttpPost]
        [Route("submit")]
        public async Task<IActionResult> CreateNewOrder([FromBody] DeliveryAddressDto? dto)
        {
            await _mediator.Send(new CreateNewOrderCommand(dto));
            return Ok();
        }

        [HttpPost]
        [Route("pay-for-order/{id}")]
        public async Task<IActionResult> PayForOrder([FromRoute] int id)
        {
            //pay for order
            await _mediator.Send(new PayForOrderCommand(id));

            //generate invoice 
            var invoiceData = new InvoiceDataDto()
            {
                User = await _dataAccess.GetUserById(await GetUserId()),
                Products = await _dataAccess.GetUsersCartItems(await GetUserId())
            };

            var invoice = await _mediator.Send(new GenerateInvoiceCommand(invoiceData));
            var invoiceUrl = await _mediator.Send(new UploadInvoiceCommand(invoice));

            //add invoice to order

            AddInvoiceToOrderDto addInvoiceToOrderDto = new()
            {
                orderId = id,
                userId = await GetUserId(),
                invoiceUrl = invoiceUrl
            };

            await _mediator.Publish(new AddInvoiceUrlToOrderNotification(addInvoiceToOrderDto));

            //send an email for a user with generated invoice

            var dataToSendAnEmail = new SendEmailWithInvoiceDto()
            {
                user = await _dataAccess.GetUserById(await GetUserId()),
                invoice = invoice,
            };

            await _mediator.Publish(new SendEmailWithInvoiceNotification(dataToSendAnEmail));


            return Ok("Payment succeeded. Invoice has been sent on your email address.");
        }

        private async Task<int?> GetUserId() => await _mediator.Send(new GetUserIdQuery());
    }
}
