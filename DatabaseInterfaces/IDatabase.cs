using System.Collections.Generic;

namespace PracticalCodingTest.DatabaseInterfaces
{
    public interface IDatabase<T>
    {
        void Insert(T data);
        IEnumerable<T> GetAll();
    }
}
