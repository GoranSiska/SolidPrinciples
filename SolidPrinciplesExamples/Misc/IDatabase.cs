
using System;

namespace SolidPrinciplesExamples.Misc
{
    public interface IDatabase<T> : IDisposable
    {
        void Store(T entity);
    }

    public class Database<T> : IDatabase<T>
    {
        public void Store(T entity)
        {
            //code for storing entity
        }

        public void Dispose()
        {
            //release unmanaged resources
        }
    }
}
