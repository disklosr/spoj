using System.IO;
using Katas.Solutions.Common;
using Katas.Solutions.SPOJ.PRIME1;
using NUnit.Framework;

namespace Katas.Solutions.SPOJ.RENT
{
    public class Test
    {
        [Test]
        public void Given_Input_Should_Return_Correct_Output()
        {
            GetType().RunTest(Rent.Main);
        }
    }
}