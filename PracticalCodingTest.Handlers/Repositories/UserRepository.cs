using System;
using System.Collections.Generic;
using System.Linq;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.Handlers
{
    public class UserRepository : IUserRepository
    {
        private IDatabase<User> _database;

        public UserRepository(IDatabase<User> database)
        {
            _database = database;
        }

        public void Add(User entity)
        {
            _database.Insert(entity);
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List()
        {
            return _database.GetAll();
        }

        public IEnumerable<User> List(Func<User, bool> predicate)
        {
            return List().Where(predicate);
        }
    }
}
