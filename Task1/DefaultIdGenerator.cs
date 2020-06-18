using System;


namespace Task1
{
    public sealed class DefaultIdGenerator : IIdGenerator
    {
        public long CalculateId()
        {
            long id = DateTime.Now.Ticks;
            return id;
        }
    }
}
