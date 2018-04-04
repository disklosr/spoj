using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

namespace Katas.Solutions
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
    }
}