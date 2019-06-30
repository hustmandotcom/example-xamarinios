using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PracticalCodingTest.Data
{
    public class Password
    {
        private readonly string _passwordString;
        public string PasswordString
        {
            get => _passwordString;
            private set => ValidPassword(value);
        }

        private string ValidPassword(string value)
        {
            if (!value.Any(char.IsDigit))
                throw new ArgumentException("Password must contain atleast 1 number");
            if (!value.Any(char.IsLetter))
                throw new ArgumentException("Password must contain atleast 1 letter");

            var specialCharacters = Regex.Replace(value, "[a-zA-Z\\d]", "");

            if (specialCharacters.Length > 0)
                throw new ArgumentException("Password can only contain numbers and letters");
            
            if (value.Length < 5 || value.Length > 12)
                throw new ArgumentException("Password must be between 5 and 12 characters");
            return value;
        }

        public Password(string password)
        {
            PasswordString = password;
        }

    }
}
