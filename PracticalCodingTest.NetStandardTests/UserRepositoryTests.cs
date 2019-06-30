
using NUnit.Framework;
using PracticalCodingTest.Data;
using PracticalCodingTest.Handlers;

namespace PracticalCodingTest.NetStandardTests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IDatabase<User> _mockDatabase;
        private IUserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _userRepository = new UserRepository(_mockDatabase);
        }

        [Test]
        public void AddingUserAddsToDatabase()
        {
        }
    }
}
