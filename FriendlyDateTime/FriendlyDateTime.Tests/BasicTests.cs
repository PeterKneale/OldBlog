using System;
using FriendlyDateTime.Code.Environment;
using FriendlyDateTime.Code.Extensions;
using NUnit.Framework;

namespace FriendlyDateTime.Tests
{
    [TestFixture]
    public class BasicTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            // Set the date so that tests have a base date to work. 
            // A class that retrieves the current time is technically a dependancy
            // that needs to be satisfied in order to properly unit test the extension method.
            // current date is Wednesday, 29th Feb 2012 at 8:30:00 PM 
            var simulatedDate = new DateTime(2012, 2, 29, 20, 30, 00);
            
            // 29/02/2012 8:30:00 PM    LOCAL
            SystemTime.Now = () => simulatedDate;
            
            // 29/02/2012 9:30:00 AM	UTC
            SystemTime.UtcNow = () => simulatedDate.ToUniversalTime();      
            
        }

        [Test]

        // Test Now
        [TestCase(2012, 2, 29, 20, 30, 00, DateTimeKind.Local, "just now")]

        // Test Now an a few seconds into the past
        [TestCase(2012, 2, 29, 20, 29, 59, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 29, 58, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 29, 57, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 29, 56, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 29, 55, DateTimeKind.Local, "just now")]

        // Test Now and a few seconds into the future
        [TestCase(2012, 2, 29, 20, 30, 05, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 30, 04, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 30, 03, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 30, 02, DateTimeKind.Local, "just now")]
        [TestCase(2012, 2, 29, 20, 30, 01, DateTimeKind.Local, "just now")]

        // Test Seconds into the future
        [TestCase(2012, 2, 29, 20, 30, 06, DateTimeKind.Local, "in 6 seconds")]
        [TestCase(2012, 2, 29, 20, 30, 15, DateTimeKind.Local, "in 15 seconds")]
        [TestCase(2012, 2, 29, 20, 30, 45, DateTimeKind.Local, "in 45 seconds")]
        
        // Test Seconds into the past
        [TestCase(2012, 2, 29, 20, 29, 54, DateTimeKind.Local, "6 seconds ago")]
        [TestCase(2012, 2, 29, 20, 29, 45, DateTimeKind.Local, "15 seconds ago")]
        [TestCase(2012, 2, 29, 20, 29, 15, DateTimeKind.Local, "45 seconds ago")]
        [TestCase(2012, 2, 29, 20, 29, 01, DateTimeKind.Local, "59 seconds ago")]

        // Test Minutes into the future
        [TestCase(2012, 2, 29, 20, 31, 00, DateTimeKind.Local, "in a minute")]
        [TestCase(2012, 2, 29, 20, 32, 00, DateTimeKind.Local, "in 2 minutes")]
        [TestCase(2012, 2, 29, 20, 33, 00, DateTimeKind.Local, "in 3 minutes")]
        
        // Test Minutes into the past
        [TestCase(2012, 2, 29, 20, 29, 00, DateTimeKind.Local, "a minute ago")]
        [TestCase(2012, 2, 29, 20, 28, 00, DateTimeKind.Local, "2 minutes ago")]
        [TestCase(2012, 2, 29, 20, 27, 00, DateTimeKind.Local, "3 minutes ago")]

        // Test Hours into the past
        [TestCase(2012, 2, 29, 19, 30, 00, DateTimeKind.Local, "an hour ago")]
        [TestCase(2012, 2, 29, 18, 30, 00, DateTimeKind.Local, "2 hours ago")]
        [TestCase(2012, 2, 29, 17, 30, 00, DateTimeKind.Local, "3 hours ago")]
        [TestCase(2012, 2, 29, 16, 30, 00, DateTimeKind.Local, "4 hours ago")]

        // Test Hours into the future
        [TestCase(2012, 2, 29, 21, 30, 00, DateTimeKind.Local, "in an hour")]
        [TestCase(2012, 2, 29, 22, 30, 00, DateTimeKind.Local, "in 2 hours")]
        [TestCase(2012, 2, 29, 23, 30, 00, DateTimeKind.Local, "in 3 hours")]
        [TestCase(2012, 3, 1, 00, 30, 00, DateTimeKind.Local, "in 4 hours")]

        public void TestJustNow(
            int year, 
            int month, 
            int day, 
            int hour, 
            int minute, 
            int second, 
            DateTimeKind kind, 
            string expected)
        {
            // Arrange
            var date = new DateTime(year, month, day, hour, minute, second, kind);

            // Act
            var output = date.ToFriendlyString();

            // Assert
            Assert.AreEqual(expected, output);
        }
    }
}
