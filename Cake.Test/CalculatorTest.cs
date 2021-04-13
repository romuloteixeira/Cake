using MyLibrary;
using NUnit.Framework;

namespace Cake.Test
{
    public class CalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 2, 3)]
        [TestCase(5, 5, 10)]
        [TestCase(270, 405, 675)]
        public void Add_SimpleAddTest_Success(int a, int b, int expected)
        {
            var calc = new Calculator();
            var actual = calc.Add(a, b);
            
            Assert.AreEqual(expected, actual);
        }
    }
}