using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Katas.Solutions.SPOJ.PRIME1
{
    public class Prime1
    {
        private double _squareRootOfInput;

        public static void Main()
        {
            //MinimizeFootprint();
            new Prime1().Solve();
        }

        public void Solve()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var mins = new int[numberOfInputs];
            var maxs = new int[numberOfInputs];

            string[] boundaries;

            for (int i = 0; i < numberOfInputs; i++)
            {
                boundaries = Console.ReadLine().Split(' ');
                mins[i] = int.Parse(boundaries[0]);
                maxs[i] = int.Parse(boundaries[1]);
            }

            var maxBoundary = maxs.Max();
            var calculatedPrimeNumbers = new List<int>(maxBoundary) {2, 3, 5};


            //Find all primes
            for (var k = 7; k <= maxBoundary; k += 2)
            {
                if (IsPrime(k))
                {
                    calculatedPrimeNumbers.Add(k);
                }
            }

            for (var t=0; t < numberOfInputs; t++)
            {
                foreach (var primeNumber in calculatedPrimeNumbers)
                {
                    if(mins[t] <= primeNumber && maxs[t] >= primeNumber)
                        Console.WriteLine(primeNumber);
                }
                
                Console.WriteLine();
            }
        }

        private bool IsPrime(int i)
        {
            _squareRootOfInput = Math.Ceiling(Math.Sqrt(i));

            for (int k = 3; k <= _squareRootOfInput; k++)
            {
                if (i % k == 0)
                    return false;
            }

            return true;
        }
    }
}