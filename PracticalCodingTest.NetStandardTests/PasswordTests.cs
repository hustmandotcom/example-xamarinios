using System.Linq;
using NUnit.Framework;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.UnitTests
{
    [TestFixture]
    public class PasswordTests
    {
        [Test]
        public void EmptyPasswordAddsValidationResult()
        {
            // arrange
            var password = "";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();

            // assert
            Assert.That(user.Errors.ContainsKey("Password"));
        }

        [Test]
        public void PasswordWithoutNumberFailsValidation()
        {
            // arrange
            var password = "abcde";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustContainNumber));
        }

        [Test]
        public void PasswordWithoutLetterFailsValidation()
        {
            // arrange
            var password = "12345";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustContainLetter));
        }

        [Test]
        public void PasswordWithSpecialCharactersFailsValidation()
        {
            // arrange
            var password = "12345a$";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustNotContainSpecialCharacters));
        }
        [Test]
        public void PasswordShorterThan5CharactersFailsValidation()
        {
            // arrange
            var password = "12a";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustBeBetween5And12Characters));
        }
        [Test]
        public void PasswordLongerThan12CharactersFailsValidation()
        {
            // arrange
            var password = "12a1231231231";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustBeBetween5And12Characters));
        }
        [Test]
        public void PasswordWithRepeatingSequenceAtEndFailsValidation()
        {
            // arrange
            var password = "12asd33333";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void PasswordWithRepeatingSequenceAtBeginningFailsValidation()
        {
            // arrange
            var password = "11111asdvxc";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void PasswordWithRepeatingSequenceAtMiddleFailsValidation()
        {
            // arrange
            var password = "axv22222asd";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void PasswordWithRepeatingSequenceFailsValidation()
        {
            // arrange
            var password = "22222a222";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();
            var errorKeyValuePair = user.Errors.FirstOrDefault(e => e.Key.Equals("Password"));

            // assert
            Assert.NotNull(errorKeyValuePair);
            Assert.That(errorKeyValuePair.Key.Equals("Password"));
            Assert.That(errorKeyValuePair.Value.Equals(ValidationMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void CorrectPasswordIsValid()
        {
            // arrange
            var password = "abcd4321";
            var username = "Test user";

            // act
            var user = new User(username, password);
            user.Validate();

            // assert
            Assert.That(user.Errors.Count < 1);
        }
    }
}
