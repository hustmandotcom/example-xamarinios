using System;
using System.Collections.Generic;
using System.Linq;
using PracticalCodingTest.Data;
using PracticalCodingTest.DatabaseInterfaces;
using PracticalCodingTest.DomainInterfaces;

namespace PracticalCodingTest.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabase<User> _database;

        public IEnumerable<User> Users
        {
            get => _database?.GetAll();
        }

        public UserRepository(IDatabase<User> database)
        {
            _database = database;
        }

        public void AddUser(User entity)
        {
            _database.Insert(entity.Clone());
        }

        public User GetUserByUsername(string username)
        {
            if (Users.FirstOrDefault(u => u.Username.Equals(username)) is User user)
                return user;
            throw new IndexOutOfRangeException(ExceptionMessagesConstant.UserDoesNotExist);
        }
    }
}
