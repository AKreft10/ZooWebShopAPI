using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Feautures.Carts.Commands;
using ZooWebShopAPI.Feautures.Carts.Queries;
using ZooWebShopAPI.Feautures.Invoices.Commands;
using ZooWebShopAPI.Models;
using ZooWebShopAPI.Persistence.DbContexts;

namespace ZooWebShopAPI.Controllers
{
    [ApiController]
    [Route("cart")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _dbcontext;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var cartItems = await _mediator.Send(new GetCartItemsQuery());
            return Ok(cartItems);
        }

        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddItemToCart([FromBody]AddProductToCartDto dto)
        {
            await _mediator.Send(new AddProductToCartCommand(dto));
            return Ok();
        }
    }
}
