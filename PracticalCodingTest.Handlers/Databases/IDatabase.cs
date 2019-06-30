using System;
using System.Collections.Generic;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.Handlers
{
    public interface IDatabase<T>
    {
        void Insert(T data);
        IEnumerable<T> GetAll();
    }
}
