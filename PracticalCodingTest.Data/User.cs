using System;

namespace PracticalCodingTest.Data
{
    public class User : ICloneable
    {
        public User(string username, Password password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public Password Password { get; set; }

        public User Clone()
        {
            var userClone = new User(this.Username, this.Password);
            return userClone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
