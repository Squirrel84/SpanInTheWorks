using System;
using System.Collections.Generic;
using System.Linq;

namespace SpanInTheWorks
{
    public class ActionSplitter
    {
        public string[] SplitAction(string actionPhrase, char splitChar)
        {
            return actionPhrase.Split(splitChar);
        }

        public string[] SplitActionSubString(string actionPhrase, char splitChar)
        {
            int[] indexes = new int[2];

            indexes[0] = actionPhrase.IndexOf(splitChar);
            if (indexes[0] > -1)
            {
                var otherPart = actionPhrase.Substring(indexes[0]+1);
                indexes[1] = otherPart.IndexOf(splitChar);
            }

            return new[] {
                actionPhrase.Substring(0, indexes[0]).ToString(),
                actionPhrase.Substring(indexes[0] + 1, indexes[1]).ToString(),
                actionPhrase.Substring(indexes[0] + 2 + indexes[1]).ToString()
            };
        }

        public string[] SplitActionAsEnumerable(IEnumerable<char> actionPhrase, char splitChar)
        {
            int[] indexes = new int[2];

            int x = 0;
            foreach (char part in actionPhrase)
            {
                if (part == splitChar)
                {
                    indexes[0] = x;
                }
                x++;
            }

            return new[] {
                actionPhrase.Skip(0).Take(indexes[0]).ToString(),
                actionPhrase.Skip(indexes[0] + 1).Take(indexes[1]).ToString(),
                actionPhrase.Skip(indexes[0] + 2).Take(indexes[1]).ToString()
            };
        }

        public string[] SplitActionSpan(ReadOnlySpan<char> actionPhrase, char splitChar)
        {
            int[] indexes = new int[2];

            indexes[0] = actionPhrase.IndexOf(splitChar);
            if (indexes[0] > -1)
            {
                var otherPart = actionPhrase.Slice(indexes[0] + 1);
                indexes[1] = otherPart.IndexOf(splitChar);
            }

            return new[] {
                actionPhrase.Slice(0, indexes[0]).ToString(),
                actionPhrase.Slice(indexes[0] + 1, indexes[1]).ToString(),
                actionPhrase.Slice(indexes[0] + 2 + indexes[1]).ToString()
            };
        }
    }
}
