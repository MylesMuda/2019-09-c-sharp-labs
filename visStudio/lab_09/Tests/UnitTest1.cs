using NUnit.Framework;
using System;
using lab_13_test_me_out;
using Sam_Rabbit_Explosion;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void TestMeSomethingTest()
        //{
        //    var expected = 100;
        //    var output = TestMeSomething.RunThisTest(10);
        //    Assert.AreEqual(expected, output);
        //}

        //[TestCase(10, 100)]
        //[TestCase(9,81)]

        //[Test]
        //public void TestMeSomethingTest_run(int input, int expected)
        //{
        //    var output = TestMeSomething.RunThisTest(10);
        //    Assert.AreEqual(expected, output);
        //}

        [TestCase(1000, 20)]
        public void TestRabbitExplosion(int populationLimit, int expYears)
        {
            //arrange 

            //act
            var actualYears = Sam_Rabbit_Explosion.JustDoItRabbitExplosion.RabbitExponentialGrowth(populationLimit).ToTuple().Item1;
            //assert
            Assert.AreEqual(actualYears, expYears);
        }
    }
}