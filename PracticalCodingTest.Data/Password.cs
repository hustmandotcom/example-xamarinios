using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PracticalCodingTest.Data
{
    public class Password
    {
        private const int MinimumPasswordLength = 5;
        private const int MaximumPasswordLength = 12;
        private const int MinimumSequenceLength = 2;
        private const int MaximumSequenceLength = 6;
        private string _passwordString;
        public string PasswordString
        {
            get => _passwordString;
            private set { _passwordString = ValidPassword(value); }
        }

        private string ValidPassword(string value)
        {
            if (!value.Any(char.IsDigit))
                throw new ArgumentException(ExceptionMessagesConstant.MustContainNumber);
            if (!value.Any(char.IsLetter))
                throw new ArgumentException(ExceptionMessagesConstant.MustContainLetter);

            var specialCharacters = Regex.Replace(value, "[a-zA-Z\\d]", "");
            if (specialCharacters.Length > 0)
                throw new ArgumentException(ExceptionMessagesConstant.MustNotContainSpecialCharacters);
            
            if (value.Length < MinimumPasswordLength || value.Length > MaximumPasswordLength)
                throw new ArgumentException(ExceptionMessagesConstant.MustBeBetween5And12Characters);

            if (PatternFound(value))
                throw new ArgumentException(ExceptionMessagesConstant.MustNotContainPatterns);

            return value;
        }

        private bool PatternFound(string value)
        {
            for (int startingIndex = 0; startingIndex < value.Length; startingIndex++)
            {
                for (int stringLength = MinimumSequenceLength; stringLength < MaximumSequenceLength; stringLength++)
                {
                    var stringToCheckIndex = startingIndex + stringLength;
                    if (value.Length < stringToCheckIndex + stringLength) continue;
                    var stringToMatch = value.Substring(startingIndex, stringLength);
                    var stringToCheck = value.Substring(stringToCheckIndex, stringLength);
                    if (stringToMatch.Equals(stringToCheck)) return true;
                }
            }
            return false;
        }

        public Password(string password)
        {
            PasswordString = password;
        }

    }
}
