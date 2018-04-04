using System.IO;
using NUnit.Framework;

namespace Katas.Solutions.SPOJ.RENT
{
    public class Test
    {
        [Test]
        public void Given_Input_Should_Return_Correct_Output()
        {
            var inOutsMap = TestHelpers.GetTestFilesDictionnary(GetType());

            foreach (var testCase in inOutsMap)
            {
                var output = TestHelpers.InitConsoleForTests(testCase.Key);
                
                Rent.Main();
                
                Assert.AreEqual(testCase.Value, output.ToString().Trim());
            }
        }
    }
}