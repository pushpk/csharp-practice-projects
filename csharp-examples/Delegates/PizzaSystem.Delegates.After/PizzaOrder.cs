using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSystem.Delegates.After
{
    public delegate decimal CalculateDiscountBasedOnOffer(IEnumerable<Pizza> pizzas);

    public class PizzaOrder
    {
        public IEnumerable<Pizza> Pizzas { get; set; }

        public decimal  CalculateDiscount(CalculateDiscountBasedOnOffer logic)
        {
            return logic(Pizzas);
        }
    }
}
