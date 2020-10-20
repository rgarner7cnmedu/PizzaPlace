﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPlace.Shared
{
    public class Menu
    {
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Pizza GetPizza(int id)
        {
            return Pizzas.SingleOrDefault(p => p.Id == id);
        }
    }
}
