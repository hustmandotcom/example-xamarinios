using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticalCodingTest.Data
{
    class PasswordValidationAttribute : ValidationAttribute
    {
        private const int MinimumPasswordLength = 5;
        private const int MaximumPasswordLength = 12;
        private const int MinimumSequenceLength = 2;
        private const int MaximumSequenceLength = 6;

        private static ValidationResult Validate(string value)
        {
            if (!value.Any(char.IsDigit))
                return new ValidationResult(ValidationMessagesConstant.MustContainNumber);
            if (!value.Any(char.IsLetter))
                return new ValidationResult(ValidationMessagesConstant.MustContainLetter);

            var specialCharacters = Regex.Replace(value, "[a-zA-Z\\d]", "");
            if (specialCharacters.Length > 0)
                return new ValidationResult(ValidationMessagesConstant.MustNotContainSpecialCharacters);

            if (value.Length < MinimumPasswordLength || value.Length > MaximumPasswordLength)
                return new ValidationResult(ValidationMessagesConstant.MustBeBetween5And12Characters);

            if (PatternFound(value))
                return new ValidationResult(ValidationMessagesConstant.MustNotContainPatterns);

            return ValidationResult.Success;
        }

        private static bool PatternFound(string value)
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

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return Validate(value.ToString());
        }
    }
}
