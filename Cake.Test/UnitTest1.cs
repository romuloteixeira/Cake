using NUnit.Framework;

namespace Cake.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var calc = new Calculator.Program();
            var result = calc.Add(1, 2);
            Assert.AreEqual(result, 3);
        }
    }
}