using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.Handlers
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
