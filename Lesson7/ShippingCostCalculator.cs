public class ShippingCostCalculator
{
    public double Calculate(Order order, IShippingStrategy shippingCostStrategy) => shippingCostStrategy.Calculate(order);
}
