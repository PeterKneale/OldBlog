using System;
using FriendlyDateTime.Code.Environment;
using FriendlyDateTime.Code.Extensions;
using NUnit.Framework;

namespace FriendlyDateTime.Tests
{
    [TestFixture]
    public class DateTimeKindTests 
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            // Set the date so that tests have a base date to work. A class that retrieves the current time is technically a dependancy
            // that needs to be satisfied in order to properly unit test the extension method.
            // current date is Wednesday, 29th Feb 2012 at 8:30:00 PM 
            var simulatedDate = new DateTime(2012, 2, 29, 20, 30, 00);
            SystemTime.Now = () => simulatedDate;                           // 29/02/2012 8:30:00 PM    LOCAL
            SystemTime.UtcNow = () => simulatedDate.ToUniversalTime();      // 29/02/2012 9:30:00 AM	UTC
        }

        [Test]
        public void TestNonUtc()
        {
            // Arrange
            var date = new DateTime(2012, 2, 29, 20, 20, 00);                                   // 10 minutes ago
            var expected = "10 minutes ago";

            // Act
            var output = date.ToFriendlyString();

            // Assert
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestUtc()
        {
            // Arrange
            var date = new DateTime(2012, 2, 29, 9, 20, 00, DateTimeKind.Utc);                  // 10 minutes ago
            var expected = "10 minutes ago";

            // Act
            var output = date.ToFriendlyString();

            // Assert
            Assert.AreEqual(expected, output);
        }


        [Test]
        public void TestUndefinedShouldBehaveAsLocal()
        {
            // Arrange
            var date = new DateTime(2012, 2, 29, 20, 20, 00, DateTimeKind.Unspecified);         // 10 minutes ago
            var expected = "10 minutes ago";

            // Act
            var output = date.ToFriendlyString();

            // Assert
            Assert.AreEqual(expected, output);
        }
    }
}
