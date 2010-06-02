using System;
using System.Windows;
using DietRecorder.Client.Common.Converters;
using NUnit.Framework;

namespace DietRecorder_Tests.Client.Common.Converters
{
    [TestFixture]
    public class VisibleConverter_Tests
    {
        [Test]
        public void Convert_PassedTrue_ReturnsVisible()
        {
            // arrange
            VisibleConverter converter = new VisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(true, typeof(Visibility), null, System.Globalization.CultureInfo.InvariantCulture);

            // assert
            Assert.AreEqual(Visibility.Visible, result);
        }

        [Test]
        public void Convert_PassedFalse_ReturnsHidden()
        {
            // arrange
            VisibleConverter converter = new VisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(false, typeof(Visibility), null, System.Globalization.CultureInfo.InvariantCulture);

            // assert
            Assert.AreEqual(Visibility.Hidden, result);
        }
    }
}
