using BenchmarkDotNet.Running;
using System;

namespace SpanInTheWorks
{
    class Program
    {
        //private static string ActionPhrase = "Order.Update.123";
        //private const char splitChar = '.';

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ActionSplitterBenchmarkTests>();

            //ActionSplitter ActionSplitter = new ActionSplitter();

            //var result = ActionSplitter.SplitActionSubString(ActionPhrase, splitChar);

            //Console.WriteLine($"{result[1]} {result[0]} {result[2]}");

            Console.Read();
        }

        
    }
}
