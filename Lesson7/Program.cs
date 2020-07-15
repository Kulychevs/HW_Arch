class Program
{
    static void Main()
    {
        var costCalculation = new ShippingCostCalculator().Calculate(new Order(), new EmsStrategy());
    }
}

