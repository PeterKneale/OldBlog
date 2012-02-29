using System;
using FriendlyDateTime.Code.Environment;
using FriendlyDateTime.Code.Extensions;
using NUnit.Framework;

namespace FriendlyDateTime.Tests
{
    [TestFixture]
    public class SystemTimeTests
    {
        [Test]
        public void TestSettingADateInThePast()
        {
            // Arrange
            var simulatedDate = new DateTime(2000, 1, 1);
            var expected = DayOfWeek.Saturday;

            SystemTime.Now = () => simulatedDate;

            // Act
            var actual = SystemTime.Now().DayOfWeek;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSettingADateInTheFuture()
        {
            // Arrange
            var simulatedDate = new DateTime(2100, 1, 1);
            var expected = DayOfWeek.Friday;

            SystemTime.Now = () => simulatedDate;

            // Act
            var actual = SystemTime.Now().DayOfWeek;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
