using System;
using NUnit.Framework;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.NetStandardTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void PasswordWithoutNumberThrowsArgumentException()
        {
            // arrange
            var passwordString = "abc";

            // act / assert
            Assert.Throws<ArgumentException>(() => new Password(passwordString));
        }
        [Test]
        public void PasswordWithoutLetterThrowsArgumentException()
        {
            // arrange
            var passwordString = "123";

            // act / assert
            Assert.Throws<ArgumentException>(() => new Password(passwordString));
        }
        [Test]
        public void PasswordWithSpecialCharactersThrowsArgumentException()
        {
            // arrange
            var passwordString = "123abc%";

            // act / assert
            Assert.Throws<ArgumentException>(() => new Password(passwordString));
        }
        [Test]
        public void PasswordShorterThan5CharactersThrowsException()
        {
            // arrange
            var passwordString = "1a";

            // act / assert
            Assert.Throws<ArgumentException>(() => new Password(passwordString));
        }
        [Test]
        public void PasswordLongerThan12CharactersThrowsException()
        {
            // arrange
            var passwordString = "1a1a1a1a1a1a1";

            // act / assert
            Assert.Throws<ArgumentException>(() => new Password(passwordString));
        }
        [Test]
        public void ProperFormattedPasswordIsValid()
        {
            // arrange
            var passwordString = "123abc123";

            // act / assert
            Assert.DoesNotThrow(() => new Password(passwordString));
        }
    }
}
