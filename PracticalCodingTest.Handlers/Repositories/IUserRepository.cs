using System;
using System.Collections.Generic;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.Handlers
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void AddUser(User user);
        User GetUserByUsername(string username);
    }
}
