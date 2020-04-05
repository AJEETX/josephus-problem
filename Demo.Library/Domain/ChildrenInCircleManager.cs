using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Library.Domain
{
    public class ChildrenInCircleManager
    {
        static IChildrenInCircleService _childrenInCircleService;
        public ChildrenInCircleManager(IChildrenInCircleService childrenInCircleService)
        {
            _childrenInCircleService = childrenInCircleService;
        }
        public static ResultData GetResult(int childrenCount, int stepCount)
        {
            var allChildrenRemovedIncludingWinner = _childrenInCircleService.GetRemovedChildrenInOrderIncludingLastChildAsWinner(childrenCount, stepCount);

            var removedChildren = allChildrenRemovedIncludingWinner.Take(childrenCount - 1);

            var Winner = allChildrenRemovedIncludingWinner.Last();

            return new ResultData
            {
                RemovedChildrenSequence = removedChildren,
                WinningChild = Winner
            };
        }
    }
}
