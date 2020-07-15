public class UpsStrategy : IShippingStrategy
{
    public double Calculate(Order order)
    {
        return 4;
    }
}
