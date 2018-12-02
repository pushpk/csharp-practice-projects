using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSystem.Delegates.After
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaOrder order = new PizzaOrder();
            order.Pizzas = new List<Pizza>
            {
                 new Pizza { crust = Crust.Thin, size = Size.Small, price = 7.00m },
            new Pizza { crust = Crust.Stuffed, size = Size.Large, price = 15.00m },
            new Pizza { crust = Crust.Regular, size = Size.Medium, price = 10.00m }

            };

            PizzaOrderingSystemMethod m = new PizzaOrderingSystemMethod();
            var total = m.ComputePrice(order);

            Console.WriteLine(total);
            Console.ReadKey();

        }


    }




    public class PizzaOrderingSystemMethod
    {

        private readonly DiscountPoliciesMethods _discountPoliciesMethods;
        public PizzaOrderingSystemMethod()
        {
            _discountPoliciesMethods = new DiscountPoliciesMethods();
        }

        public decimal ComputePrice(PizzaOrder order)
        {
            decimal total = order.Pizzas.Sum(p => p.price);

            decimal[] discounts = new[] {
            _discountPoliciesMethods.BuyOneGetOneFree(order),
            _discountPoliciesMethods.FivePercentOffMoreThanFiftyDollars(order),
            _discountPoliciesMethods.FiveDollarsOffStuffedCrust(order),
        };

            decimal bestDiscount = discounts.Max(discount => discount);
            total = total - bestDiscount;
            return total;
        }

    }

    //public delegate decimal DiscountPolicy(PizzaOrder order);

    public class DiscountPoliciesMethods
    {
        public decimal BuyOneGetOneFree(PizzaOrder order)
        {
            var pizzas = order.Pizzas;
            if (pizzas.Count() > 2)
            {
                return pizzas.Min(p => p.price);

            }
            else
            {

                return 0m;

            }
        }

        public decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
        {
            decimal v = order.Pizzas.Sum(s => s.price);
            return v >= 50 ? v * 0.05m : 0m;
        }

        public decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
        {
            return order.Pizzas.Sum(p => p.crust == Crust.Stuffed ? 5m : 0m);

        }

    }
}
