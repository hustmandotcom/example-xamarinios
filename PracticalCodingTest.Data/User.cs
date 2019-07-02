using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace PracticalCodingTest.Data
{
    public class User : ICloneable
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsValid => Errors.Count < 1;

        public IReadOnlyDictionary<string, string> Errors { get; private set; }

        public User Clone()
        {
            var userClone = new User(this.Username, this.Password);
            return userClone;
        }

        public User ValidatePassword()
        {
            var dictionary = new Dictionary<string, string>();
            var results = new List<ValidationResult>();

            results.Add(ValidatePasswordValidationResult(Password, nameof(Password)));

            Errors = new ReadOnlyDictionary<string, string>(dictionary.AddValidationResults(results));

            return this;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static User DefaultUser()
        {
            return new User("", "");
        }

        #region Password Validation

        private const int MinimumPasswordLength = 5;
        private const int MaximumPasswordLength = 12;
        private const int MinimumSequenceLength = 2;
        private const int MaximumSequenceLength = 6;

        private ValidationResult ValidatePasswordValidationResult(string value, string memberName)
        {
            if (!value.Any(char.IsDigit))
                return new ValidationResult(ValidationMessagesConstant.MustContainNumber,
                    new List<string>() {memberName});
            if (!value.Any(char.IsLetter))
                return new ValidationResult(ValidationMessagesConstant.MustContainLetter,
                    new List<string>() {memberName});

            var specialCharacters = Regex.Replace(value, "[a-zA-Z\\d]", "");
            if (specialCharacters.Length > 0)
                return new ValidationResult(ValidationMessagesConstant.MustNotContainSpecialCharacters,
                    new List<string>() {memberName});

            if (value.Length < MinimumPasswordLength || value.Length > MaximumPasswordLength)
                return new ValidationResult(ValidationMessagesConstant.MustBeBetween5And12Characters,
                    new List<string>() {memberName});

            if (PatternFound(value))
                return new ValidationResult(ValidationMessagesConstant.MustNotContainPatterns,
                    new List<string>() {memberName});

            return ValidationResult.Success;
        }

        public void ValidateUsername(IEnumerable<string> currentUsernames)
        {
            var dictionary = new Dictionary<string, string>();

            if (currentUsernames.Contains(Username))
            {
                dictionary.Add("Username", "Username already exists");
            }

            Errors = new ReadOnlyDictionary<string, string>(dictionary);
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

        #endregion
    }
}