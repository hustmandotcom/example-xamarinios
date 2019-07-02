using System.Collections.Generic;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.DomainInterfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void AddUser(User user);
        User GetUserByUsername(string username);
    }
}
