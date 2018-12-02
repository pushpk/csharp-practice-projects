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
        public decimal ComputePrice(PizzaOrder order)
        {
            decimal total = order.Pizzas.Sum(p => p.price);
            var BuyOneGetOneFree = order.CalculateDiscount(o => o.Count() >= 2 ? o.Min(s => s.price) : 0m);
            var FivePercentOffMoreThanFiftyDollars = order.CalculateDiscount(o => 
            {
                decimal v = o.Sum(s => s.price);
                return v >= 50 ? v * 0.05m : 0m;
            });
            var FiveDollarsOffStuffedCrust = order.CalculateDiscount(o => o.Sum(p => p.crust == Crust.Stuffed ? 5m : 0m));

            Console.WriteLine($"Buy One Get One Discount: {BuyOneGetOneFree.ToString()}");
            Console.WriteLine($"Five Percent Off More Than Fifty Dollars Discount: {FivePercentOffMoreThanFiftyDollars.ToString()}");
            Console.WriteLine($"Five Dollars Off Stuffed Crust: {FiveDollarsOffStuffedCrust.ToString()}");
             
            total = total - new[] { BuyOneGetOneFree, FivePercentOffMoreThanFiftyDollars, FiveDollarsOffStuffedCrust }.Max(discount => discount); ;
            return total;
        }
    }

}


