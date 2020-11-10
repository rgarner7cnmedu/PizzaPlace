using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Server.Data;
using PizzaPlace.Shared;

namespace PizzaPlace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaPlaceDbContext db;
        public OrdersController(PizzaPlaceDbContext db)
        {
            this.db = db;
        }

        [HttpPost("/orders")]
        public IActionResult CreateOrder([FromBody] Basket basket)
        {
            Customer customer = basket.Customer;
            var order = new Order()
            {
                PizzaOrders = new List<PizzaOrder>()
            };
            customer.Order = order;

            foreach (int pizzaId in basket.Orders)
            {
                Pizza pizza = this.db.Pizzas.Single(pizza => pizza.Id == pizzaId);
                order.PizzaOrders.Add(new PizzaOrder { Pizza = pizza, Order = order });
            }

            order.TotalPrice = order.PizzaOrders.Sum(po => po.Pizza.Price);

            this.db.Customers.Add(customer);
            this.db.SaveChanges();
            return Ok();
        }

    }
}
