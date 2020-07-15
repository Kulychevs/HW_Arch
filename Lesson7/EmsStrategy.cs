public class EmsStrategy : IShippingStrategy
{
    public double Calculate(Order order)
    {
        return 3;
    }
}
