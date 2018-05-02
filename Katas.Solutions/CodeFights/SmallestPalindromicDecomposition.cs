using System;
using System.Collections.Generic;
using System.Linq;
using Katas.Solutions.SPOJ.PRIME1;
using NUnit.Framework;

namespace Katas.Solutions.CodeFights
{
    public class SmallestPalindromicDecomposition
    {
        private Dictionary<string, List<List<string>>> memo = new Dictionary<string, List<List<string>>>();
        private List<int> startIndices = new List<int>();
        private List<int> endIndices = new List<int>();
        private List<string> pals = new List<string>();
        private 

        string[] Solve(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= s.Length - i; j++)
                {
                    var str = s.Substring(i, j);
                    if ( str.Length > 1 && IsPal(str))
                    {
                        startIndices.Add(i);
                        endIndices.Add(j);
                        pals.Add(str);
                    }
                }
            }

            var x = FindSplits(s, 0);
            return x.OrderBy(_ => _.Count).ThenBy(_ => _.First()).First().ToArray();
        }

        List<List<string>> FindSplits(string s, int iStart)
        {
            if (memo.ContainsKey(s))
                return memo[s];

            if (IsPal(s))
                return memo[s] = new List<List<string>> {new List<string> {s}};

            var splits = Enumerable.Range(0, startIndices.Count).Where(_ => startIndices[_] >= iStart && endIndices[_] <= s.Length - 1).ToList();
            if (splits.Any())
            {
                List<List<string>> ret = new List<List<string>>();
                foreach (var split in splits)
                {
                    var left = FindSplits(s.Substring(0, startIndices[split] - iStart), iStart);
                    var center = s.Substring((startIndices[split] - iStart), endIndices[split]);
                    var right = FindSplits(s.Substring(endIndices[split], s.Length - endIndices[split]), startIndices[split] + endIndices[split]);

                    ret.Add(left.OrderBy(_ => _.Count).First().Concat(new[] {center})
                        .Concat(right.OrderBy(_ => _.Count).First()).ToList());
                }

                return memo[s] = ret;
            }

            else
            {
                return memo[s] = new List<List<string>> {s.Select(_ => _+"").ToList()};
            }
        }

        List<string> Min(List<List<string>> ls)
        {
            var min = ls.First();
            foreach (var t in ls)
            {
                min = t.Count < min.Count ? t : min;
            }

            return min;
        }

        bool IsPal(string s)
        {
            if (s.Length == 1)
                return true;

            for (int j = 0; j < s.Length / 2; j++)
            {
                if (s[j] != s[s.Length - 1 - j])
                    return false;
            }

            return true;
        }

        [Test]
        [TestCase("aracecaraba", 3)]
        public void Test(string s, int expectedNumberOfItems)
        {
            Assert.AreEqual(expectedNumberOfItems, Solve(s));
        }
    }
}