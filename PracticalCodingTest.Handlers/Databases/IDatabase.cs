using System;
using System.Collections.Generic;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.Handlers
{
    public interface IDatabase<T> where T : EntityBase
    {
        void Insert(T data);
        IEnumerable<User> GetAll();
    }
}
