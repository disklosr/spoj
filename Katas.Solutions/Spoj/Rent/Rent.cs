using System;
using System.Linq;

// ReSharper disable AssignNullToNotNullAttribute

namespace Katas.Solutions.SPOJ.RENT
{
    public class Rent
    {
        private const int MaxChoices = 100000;
        
        private readonly int[] _optionsStart;
        private readonly int[] _optionsEnd;
        private readonly int[] _optionsProfit;
        private readonly int[] _optionsMax;

        public Rent()
        {
            _optionsStart = new int[MaxChoices];
            _optionsEnd = new int[MaxChoices];
            _optionsProfit = new int[MaxChoices];
            _optionsMax = new int[MaxChoices];
        }

        public static void Main()
        {
           Rent rent = new Rent();
           rent.Solve();
        }

        public void Solve()
        {
            var numberOfTestCases = int.Parse(Console.ReadLine());

            //Foreach test case
            while (numberOfTestCases-- != 0)
            {
                var numberOfChoices = int.Parse(Console.ReadLine());
                
                //For each choice fill in the tables
                for (int k = 0; k < numberOfChoices; k++)
                {
                    string[] values = Console.ReadLine().Split(' ');
                    _optionsStart[k] = int.Parse(values[0]);
                    _optionsEnd[k] = int.Parse(values[1]) + _optionsStart[k];
                    _optionsProfit[k] = int.Parse(values[2]);
                }
                
                //Sort the tables
                Array.Sort(_optionsStart.ToArray(), _optionsEnd, 0, numberOfChoices);
                Array.Sort(_optionsStart, _optionsProfit, 0, numberOfChoices);

                //Iterate from bottom up
                for (int currentIndex = numberOfChoices - 1; currentIndex >= 0; currentIndex--)
                {
                    _optionsMax[currentIndex] = _optionsProfit[currentIndex];
                    for (int canBeReachedIndex = currentIndex; canBeReachedIndex < numberOfChoices; canBeReachedIndex++)
                    {
                        //If we can reach j from i, then profit can add up
                        if (_optionsEnd[currentIndex] < _optionsStart[canBeReachedIndex])
                        {
                            _optionsMax[currentIndex] = Math.Max(_optionsMax[currentIndex], _optionsProfit[currentIndex] + _optionsMax[canBeReachedIndex]);
                        }
                    }
                }
                
                Console.WriteLine(ArrayMax(_optionsMax, numberOfChoices).ToString());
            }
        }

        private static int ArrayMax(int[] array, int length)
        {
            int max = -1;

            for (var i = 0; i < length; i++)
            {
                var item = array[i];
                max = max > item ? max : item;
            }

            return max;
        }
    }
}