using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SpanInTheWorks
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class ActionSplitterBenchmarkTests
    {
        private const string ActionUpdatePhrase = "Order.Update.123";
        private const string ActionAddPhrase = "Order.Add.123";
        private const string ActionGetPhrase = "Order.Get.123";
        private const string ActionDeletePhrase = "Order.Delete.123";

        private static readonly ActionSplitter ActionSplitter = new ActionSplitter();
        private const char splitChar = '.';

        [Benchmark(Baseline = true)]
        public void SplitAction()
        {
            ActionSplitter.SplitAction(ActionAddPhrase, splitChar);
            ActionSplitter.SplitAction(ActionGetPhrase, splitChar);
            ActionSplitter.SplitAction(ActionUpdatePhrase, splitChar);
            ActionSplitter.SplitAction(ActionDeletePhrase, splitChar);
        }

        [Benchmark]
        public void SplitActionSubString()
        {
            ActionSplitter.SplitActionSubString(ActionAddPhrase, splitChar);
            ActionSplitter.SplitActionSubString(ActionGetPhrase, splitChar);
            ActionSplitter.SplitActionSubString(ActionUpdatePhrase, splitChar);
            ActionSplitter.SplitActionSubString(ActionDeletePhrase, splitChar);
        }

        [Benchmark]
        public void SplitActionSpan()
        {
            ActionSplitter.SplitActionSpan(ActionAddPhrase, splitChar);
            ActionSplitter.SplitActionSpan(ActionGetPhrase, splitChar);
            ActionSplitter.SplitActionSpan(ActionUpdatePhrase, splitChar);
            ActionSplitter.SplitActionSpan(ActionDeletePhrase, splitChar);
        }

        [Benchmark]
        public void SplitActionAsEnumerable()
        {
            ActionSplitter.SplitActionAsEnumerable(ActionAddPhrase, splitChar);
            ActionSplitter.SplitActionAsEnumerable(ActionGetPhrase, splitChar);
            ActionSplitter.SplitActionAsEnumerable(ActionUpdatePhrase, splitChar);
            ActionSplitter.SplitActionAsEnumerable(ActionDeletePhrase, splitChar);
        }
    }
}
