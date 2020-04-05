using Demo.Library.Model;
using System.Linq;
using System;

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
            if (childrenCount < 1 || stepCount < 1)
                return new ResultData {
                    HasError=true
                };
            var result = default(ResultData);
            try
            {
                var allChildrenRemovedIncludingWinner = _childrenInCircleService.GetRemovedChildrenInOrderIncludingLastChildAsWinner(childrenCount, stepCount);

                var removedChildren = allChildrenRemovedIncludingWinner.Take(childrenCount - 1);

                var Winner = allChildrenRemovedIncludingWinner.Last();

                result= new ResultData
                {
                    RemovedChildrenSequence = removedChildren,
                    WinningChild = Winner,
                    HasError = false
                };
            }
            catch (Exception)
            {
                //log// throw
            }
            return result;
        }
    }
}
