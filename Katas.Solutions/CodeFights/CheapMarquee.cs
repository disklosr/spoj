using System;
using System.Linq;
using NUnit.Framework;

namespace Katas.Solutions.CodeFights
{
    public class CheapMarquee
    {
        int Solve(string m, int w)
        {
            


            var u = new object[]
                {
                    "00", 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 1, 0, 3443, 2511, 2332, 3332, 2251, 4332, 3332, 2222,
                    2332, 2333, 0, 0, 0, 0, 0, 1321, 0, 4224, 5332, 3222, 5223, 5332, 5221, 3233, 5115, 2522, 2241,
                    5122, 5111, 5225, 5125, 3223, 5221, 3234, 5332, 2332, 1511, 4114, 4122, 4225, 3223, 2311, 3332
                }.Select(_ => _+"").ToArray();

            m = m.PadRight(99).ToUpper().Select(_ => _ - ' ').Where(c => c < 59 && u[c] != "0")
                .Aggregate("", (x, c) => x + (u[c] + "0"));

            return new int[9999].Select((_, i) => m.Skip(i).Take(w).Select(c => c - '0').Sum()).Max();
        }

        [Test]
        [TestCase("HEY ", 6, 18)]
        [TestCase("test", 1, 5)]
        [TestCase("Come get your Pan Galactic Gargle Blaster... at The Restaurant at the end of the universe!!", 42,
            97)]
        public void Test(string message, int width, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Solve(message, width));
        }
    }
}