using System;

namespace StockExchange.Data.Caching
{
    public interface IEngine
    {

        T Resolve<T>() where T : class;
        object Resolve(Type type);
        T[] ResolveAll<T>();

    }
}
