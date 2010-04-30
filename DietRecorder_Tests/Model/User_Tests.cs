using System;
using System.Collections.Generic;
using NUnit.Framework;
using DietRecorder.Model;

namespace DietRecorder_Tests.Model
{
    [TestFixture]
    public class User_Tests
    {
        [Test]
        public void GetValidationFailures_NameHasZeroCharacters_ReturnsCorrectMessage()
        {
            // arrange
            string name = string.Empty;
            User user = new User(name, new List<Measurement>(), new List<CustomMeasurementDefinition>());

            // act
            List<string> validationResults = user.GetValidationFailures();

            // assert
            Assert.IsNotEmpty(validationResults, "No validation message");
            Assert.AreEqual("Name must be at least 1 character long", validationResults[0], "Validation message wrong");
        }

        [Test]
        public void GetValidationFailures_NameHasOneCharacter_NoMessageReturned()
        {
            // arrange
            string name = "1";
            User user = new User(name, new List<Measurement>(), new List<CustomMeasurementDefinition>());

            // act
            List<string> validationResults = user.GetValidationFailures();

            // assert
            Assert.IsEmpty(validationResults, "Unexpected validation message");
        }

        [Test]
        public void GetValidationFailures_NameHas40Characters_NoMessageReturned()
        {
            // arrange
            string name = "1234567890123456789012345678901234567890";
            User user = new User(name, new List<Measurement>(), new List<CustomMeasurementDefinition>());

            // act
            List<string> validationResults = user.GetValidationFailures();

            // assert
            Assert.IsEmpty(validationResults, "Unexpected validation message");
        }

        [Test]
        public void GetValidationFailures_NameHas41Characters_ReturnsCorrectMessage()
        {
            // arrange
            string name = "12345678901234567890123456789012345678901";
            User user = new User(name, new List<Measurement>(), new List<CustomMeasurementDefinition>());

            // act
            List<string> validationResults = user.GetValidationFailures();

            // assert
            Assert.IsNotEmpty(validationResults, "No validation message");
            Assert.AreEqual("Name cannot be longer than 40 characters", validationResults[0], "Validation message wrong");
        }
    }
}
