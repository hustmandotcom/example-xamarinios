
using System;
using NUnit.Framework;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.UnitTests
{
    [TestFixture]
    public class PasswordTests
    {
        [Test]
        public void PasswordWithoutNumberThrowsArgumentException()
        {
            // arrange
            var passwordString = "abc";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustContainNumber));
        }
        [Test]
        public void PasswordWithoutLetterThrowsArgumentException()
        {
            // arrange
            var passwordString = "123";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustContainLetter));
        }
        [Test]
        public void PasswordWithSpecialCharactersThrowsArgumentException()
        {
            // arrange
            var passwordString = "123abc%";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustNotContainSpecialCharacters));
        }
        [Test]
        public void PasswordShorterThan5CharactersThrowsArgumentException()
        {
            // arrange
            var passwordString = "1a";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustBeBetween5And12Characters));
        }
        [Test]
        public void PasswordLongerThan12CharactersThrowsArgumentException()
        {
            // arrange
            var passwordString = "1a1a1a1a1a1a1";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustBeBetween5And12Characters));
        }
        [Test]
        public void PasswordWithRepeatingSequenceAtEndThrowsArgumentException()
        {
            // arrange
            var passwordString = "1234567878";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void PasswordWithRepeatingSequenceAtBeginningThrowsArgumentException()
        {
            // arrange
            var passwordString = "111123457";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void PasswordWithRepeatingSequenceAtMiddleThrowsArgumentException()
        {
            // arrange
            var passwordString = "123434567";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void PasswordWithRepeatingSequenceThrowsArgumentException()
        {
            // arrange
            var passwordString = "1234512345";

            // act / assert
            var ex = Assert.Throws<ArgumentException>(() => new Password(passwordString));
            Assert.That(ex.Message.Equals(ExceptionMessagesConstant.MustNotContainPatterns));
        }
        [Test]
        public void CorrectPasswordIsValid()
        {
            // arrange
            var passwordString = "123abc432";

            // act / assert
            Assert.DoesNotThrow(() => new Password(passwordString));
        }
    }
}
