using System;

namespace PracticalCodingTest.Data
{
    public class User : EntityBase
    {
        public User(string username, Password password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public Password Password { get; set; }
    }
}
