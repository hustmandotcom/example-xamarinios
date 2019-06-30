using System;
namespace PracticalCodingTest.Data
{
    public static class ExceptionMessagesConstant
    {
        public const string MustContainNumber = "Password must contain atleast 1 number";
        public const string MustContainLetter = "Password must contain atleast 1 letter";
        public const string MustNotContainSpecialCharacters = "Password can only contain numbers and letters";
        public const string MustBeBetween5And12Characters = "Password must be between 5 and 12 characters";
        public const string MustNotContainPatterns = "Password must not contain noticable patterns";
    }
}
