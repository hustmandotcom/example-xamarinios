
using System;
using NUnit.Framework;

namespace PracticalCodingTestUnitTests
{
    [TestFixture]
    public class ValidateTestsWorking
    {
        [Test]
        public void Pass()
        {
            Assert.True(true);
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }
    }
}
