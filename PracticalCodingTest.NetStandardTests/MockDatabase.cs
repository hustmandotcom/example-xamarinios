using System;
using System.Collections.Generic;
using System.Linq;
using PracticalCodingTest.Data;
using PracticalCodingTest.Handlers;

namespace PracticalCodingTest.NetStandardTests
{
    public class MockDatabase : IDatabase<User>
    {
        private readonly List<User> _users = new List<User>();

        public MockDatabase()
        {
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Insert(User data)
        {
            _users.Add(data);
        }
    }
}
