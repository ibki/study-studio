using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DotNetFramework.Test
{
    [TestClass]
    public class TryParseTests
    {
        [TestMethod]
        public void DoubleTryParse_ExponentialString()
        {
            // double ±5.0 x 10-324 ~ ±1.7 x 10+308

            // Arrange
            string minValue = "-1.7976931348623157E+308";
            string maxValue = "1.7976931348623157E+308";
            string epsilon = "4.94065645841247E-324";
            string testValue = "1.5E-02";

            // Act && Assert
            Assert.IsTrue(double.TryParse(minValue, out double minDouble));
            Assert.IsTrue(double.TryParse(maxValue, out double maxDouble));
            Assert.IsTrue(double.TryParse(epsilon, out double epsilonDouble));
            Assert.IsTrue(double.TryParse(testValue, out double testDouble));
            
            Console.WriteLine(
                $"{nameof(minDouble)} = {minDouble}\r\n\r\n" +
                $"{nameof(maxDouble)} = {maxDouble}\r\n\r\n" +
                $"{nameof(epsilonDouble)} = {epsilonDouble}\r\n\r\n" +
                $"{nameof(testDouble)} = {testDouble}\r\n\r\n");

            Console.Write(
                $"{nameof(minDouble)} = {minDouble.ToString("0." + new string('#', 339))}\r\n\r\n" +
                $"{nameof(maxDouble)} = {maxDouble.ToString("0." + new string('#', 339))}\r\n\r\n" +
                $"{nameof(epsilonDouble)} = {epsilonDouble.ToString("0." + new string('#', 339))}\r\n\r\n" +
                $"{nameof(testDouble)} = {testDouble.ToString("0." + new string('#', 339))}\r\n\r\n");

            Console.Write(
                $"{nameof(minDouble)} = {minDouble.ToString(FormatStrings.DoubleFixedPoint)}\r\n\r\n" +
                $"{nameof(maxDouble)} = {maxDouble.ToString(FormatStrings.DoubleFixedPoint)}\r\n\r\n" +
                $"{nameof(epsilonDouble)} = {epsilonDouble.ToString(FormatStrings.DoubleFixedPoint)}\r\n\r\n" +
                $"{nameof(testDouble)} = {testDouble.ToString(FormatStrings.DoubleFixedPoint)}\r\n\r\n");
        }

        public static class FormatStrings
        {
            public const string DoubleFixedPoint = "0.###################################################################################################################################################################################################################################################################################################################################################";
        }
    }
}
