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
    [ApiController]
    public class PizzasController : ControllerBase
    {
        //private static readonly List<Pizza> pizzas = new List<Pizza>
        //{
        //    new Pizza(1, "Pepperoni", 8.99M, Spiciness.Spicy),
        //    new Pizza(2, "Margarita", 7.99M, Spiciness.None),
        //    new Pizza(3, "Diabolo", 9.99M, Spiciness.Hot)
        //};

        private readonly PizzaPlaceDbContext db;

        public PizzasController(PizzaPlaceDbContext db)
        {
            this.db = db;
        }

        [HttpGet("pizzas")]
        public IQueryable<Pizza> GetPizzas()
        {
            return db.Pizzas;
        }

        [HttpPost("pizzas")]
        public IActionResult InsertPizza([FromBody] Pizza pizza )
        {
            db.Pizzas.Add(pizza);
            db.SaveChanges();
            return Created($"pizzas/{pizza.Id}", pizza);
        }



    }
}
