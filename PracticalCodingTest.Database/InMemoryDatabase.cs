using System;
using System.Collections.Generic;
using System.Linq;
using PracticalCodingTest.Data;
using PracticalCodingTest.DatabaseInterfaces;

namespace PracticalCodingTest.Database
{
    public class InMemoryDatabase : IDatabase<User>
    {
        private readonly List<User> _users = new List<User>();

        public IEnumerable<User> GetAll()
        {
            return _users.Select(u => u.Clone());
        }

        public void Insert(User data)
        {
            if (_users.FirstOrDefault(u => u.Username.Equals(data.Username)) != null)
                throw new InvalidOperationException(ExceptionMessagesConstant.UserAlreadyExists);
            _users.Add(data);
        }
    }
}
