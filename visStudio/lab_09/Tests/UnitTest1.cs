using NUnit.Framework;
using lab_13_test_me_out;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMeSomethingTest()
        {
            var expected = 100;
            var output = TestMeSomething.RunThisTest(10);
            Assert.AreEqual(expected, output);
        }

        [TestCase(10, 100)]
        [TestCase(9,82)]

        [Test]
        public void TestMeSomethingTest_run(int input, int expected)
        {
            var output = TestMeSomething.RunThisTest(10);
            Assert.AreEqual(expected, output);
        }
    }
}