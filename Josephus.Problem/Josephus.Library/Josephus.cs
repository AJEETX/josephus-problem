using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Josephus.Library
{
    class Josephus
    {

        public  static ResultData GetResult(int childrenCount, int stepCount)
        {
            var allChildrenRemovedIncludingWinner = GetRemovedChildrenInOrderAndWinner(childrenCount, stepCount);

            var removedChildren= allChildrenRemovedIncludingWinner.Take(childrenCount - 1);

            var Winner = allChildrenRemovedIncludingWinner.Last();

            return new ResultData
            {
                 RemovedChildrenSequence=removedChildren,
                  WinningChild=Winner
            };
        }
        static IEnumerable<int> GetRemovedChildrenInOrderAndWinner(int childrenCount, int stepCount)
        {

            for (var i = 1; i <= childrenCount; i++)

                yield return FindChild2Remove(childrenCount, stepCount, i);
        }
        static int FindChild2Remove(int childrenCount, int stepCount, int sequence)
        {

            var child2BeRemoved = stepCount * sequence;

            while (child2BeRemoved > childrenCount)
            {
                var temp = (child2BeRemoved - childrenCount - 1) / (stepCount - 1);

                child2BeRemoved = temp + child2BeRemoved - childrenCount;

            }
            return child2BeRemoved;
        }
    }
}
