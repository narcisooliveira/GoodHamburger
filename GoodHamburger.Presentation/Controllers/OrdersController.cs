using GoodHamburger.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(
        CreateOrder createUseCase,
        GetOrderById getOrderById,
        GetOrders getOrders,
        DeleteOrderById deleteOrderById) : ControllerBase
    {
        private readonly CreateOrder _createOrder = createUseCase;
        private readonly GetOrderById _getOrderById = getOrderById;
        private readonly GetOrders _getOrders = getOrders;
        private readonly DeleteOrderById _deleteOrderById = deleteOrderById;

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
            => Ok(await _createOrder.Execute(request));

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _getOrders.Execute());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _getOrderById.Execute(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteOrderById.Execute(id);
            if (result == 0)
                return BadRequest("Não foi possível deletar o pedido");

            return Ok("Pedido deletado com sucesso");
        }
    }
}
