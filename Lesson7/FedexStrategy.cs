public class FedexStrategy : IShippingStrategy
{
    public double Calculate(Order order)
    {
        return 5;
    }
}
