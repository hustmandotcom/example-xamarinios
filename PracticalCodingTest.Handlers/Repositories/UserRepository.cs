using System;
using System.Collections.Generic;
using System.Linq;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.Handlers
{
    public class UserRepository : IUserRepository
    {
        private IDatabase<User> _database;

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
