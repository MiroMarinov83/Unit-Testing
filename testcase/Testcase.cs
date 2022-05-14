using Collections;
using NUnit.Framework;

namespace Testcase
{
    public class Tests_With_Test_Cases
    {
        [TestCase("0,1,2", 0, "0")]
        [TestCase("0,1,2,3", 1, "1")]
        [TestCase("0,1,2,3,4", 3, "3")]
        [TestCase("0,1,2,3,4,5", 5, "5")]
        public void TestCases(string data,int index,string expectedValue)
        {
            var items = new Collection<string>(data.Split(","));
            var item = items[index];
            Assert.That(item,Is.EqualTo(expectedValue));
        }
    }
}