using System;
using System.Diagnostics;
using Katas.Solutions.Common;
using NUnit.Framework;

namespace Katas.Solutions.SPOJ.PRIME1
{
    public class Test
    {
        [Test]
        public void Given_Input_Should_Return_Correct_Output()
        {
            GetType().RunTest(Prime1.Main);
        }

        

        [TearDown]
        public void DerivedTearDown()
        {
            TestContext.WriteLine("Total memory consumed: " + Process.GetCurrentProcess().PeakWorkingSet64 / (1024 * 1024) + " MB");
        }
    }
}