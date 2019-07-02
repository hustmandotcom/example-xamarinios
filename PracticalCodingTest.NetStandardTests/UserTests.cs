using NUnit.Framework;
using PracticalCodingTest.Data;

namespace PracticalCodingTest.UnitTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void CreatingNewUserAllowsReadingUsernamePassword()
        {
            // arrange
            var username = "test user";
            var password = "123abc4332";

            // act
            var user = new User(username, password);

            // assert
            Assert.IsTrue(user.Username.Equals(username));
            Assert.IsTrue(user.Password.Equals(password));
        }
        [Test]
        public void UpdatedUsernameDoesNotMatchOriginalUsername()
        {
            // arrange
            var username = "test user";
            var newUsername = "test user 2";
            var password = "123abc4332";

            // act
            var user = new User(username, password);
            user.Username = newUsername;

            // assert
            Assert.IsFalse(user.Username.Equals(username));
            Assert.IsTrue(user.Password.Equals(password));
        }
        [Test]
        public void UpdatedUsernameDoesMatchUpdatedUsername()
        {
            // arrange
            var username = "test user";
            var newUsername = "test user 2";
            var password = "123abc4332";

            // act
            var user = new User(username, password);
            user.Username = newUsername;

            // assert
            Assert.IsTrue(user.Username.Equals(newUsername));
            Assert.IsTrue(user.Password.Equals(password));
        }
        [Test]
        public void UpdatedPasswordDoesNotMatchOriginalPassword()
        {
            // arrange
            var username = "test user";
            var password = "123abc4332";
            var updatedPassword = "1234gft54";

            // act
            var user = new User(username, password);
            user.Password = updatedPassword;

            // assert
            Assert.IsTrue(user.Username.Equals(username));
            Assert.IsFalse(user.Password.Equals(password));
        }
        [Test]
        public void UpdatedPasswordDoesMatchUpdatedPassword()
        {
            // arrange
            var username = "test user";
            var password = "123abc4332";
            var updatedPassword = "1234gft54";

            // act
            var user = new User(username, password);
            user.Password = updatedPassword;

            // assert
            Assert.IsTrue(user.Username.Equals(username));
            Assert.IsTrue(user.Password.Equals(updatedPassword));
        }
    }
}
