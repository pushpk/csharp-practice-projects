namespace PizzaSystem.Delegates.After
{
    public enum Size
    {
        Small, Medium, Large
    }

    public enum Crust
    {
        Thin, Regular, Stuffed
    }

    public class Pizza
    {
        public Size size { get; set; }
        public Crust crust { get; set; }

        public decimal price { get; set; }
    }
}