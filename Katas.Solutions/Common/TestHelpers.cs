using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

namespace Katas.Solutions.Common
{
    public static class TestHelpers
    {
        public static Dictionary<string,string> GetTestFilesDictionnary(Type problemType)
        {
            var testFolderName = string.Join("/", problemType.Namespace.Split('.').Skip(2).ToArray());
            var testFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), testFolderName))
                .Where(_ => !_.EndsWith(".cs"))
                .OrderBy(_ => _)
                .ToArray();
            
            var inOutsMap = new Dictionary<string,string>();

            for (var i = 0; i < testFiles.Length / 2; i += 2)
            {
                inOutsMap[File.ReadAllText(testFiles[i])] = File.ReadAllText(testFiles[i + 1]);
            }

            return inOutsMap;
        }

        public static StringBuilder InitConsoleForTests(string inputString)
        {
            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));
            Console.SetIn(new StringReader(inputString));

            return output;
        }
        
        public static void RunTest(this Type testType, Action action)
        {
            var inOutsMap = GetTestFilesDictionnary(testType);

            foreach (var testCase in inOutsMap)
            {
                var output = InitConsoleForTests(testCase.Key);

                action();

                Assert.AreEqual(testCase.Value, output.ToString().Trim());
            }
        }
    }
}