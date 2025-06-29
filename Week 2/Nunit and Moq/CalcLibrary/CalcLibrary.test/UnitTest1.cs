using NUnit.Framework;
using CalcLibrary; 
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [TestCase(10, 5, 15)]
        [TestCase(-10, -5, -15)]
        [TestCase(10.5, 2.5, 13.0)]
        public void Addition_ShouldReturnCorrectSum(double num1, double num2, double expected)
        {
            double result = _calculator.Addition(num1, num2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 5, 5)]
        [TestCase(-10, -5, -5)]
        [TestCase(10.5, 2.5, 8.0)]
        public void Subtraction_ShouldReturnCorrectDifference(double num1, double num2, double expected)
        {
            double result = _calculator.Subtraction(num1, num2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 5, 50)]
        [TestCase(-10, 5, -50)]
        [TestCase(10, 0, 0)]
        public void Multiplication_ShouldReturnCorrectProduct(double num1, double num2, double expected)
        {
            double result = _calculator.Multiplication(num1, num2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 5, 2)]
        [TestCase(-10, 5, -2)]
        public void Division_ShouldReturnCorrectQuotient(double num1, double num2, double expected)
        {
            double result = _calculator.Division(num1, num2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ShouldThrowException_WhenDividingByZero()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Division(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void GetResult_ShouldReturnLastOperationResult()
        {
            _calculator.Addition(20, 22);

            double result = _calculator.GetResult;

            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void AllClear_ShouldResetTheInternalResult()
        {
            _calculator.Multiplication(10, 10);
            Assert.That(_calculator.GetResult, Is.EqualTo(100));
            _calculator.AllClear();
            Assert.That(_calculator.GetResult, Is.EqualTo(0));
        }
    }
}