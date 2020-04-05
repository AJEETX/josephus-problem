using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Library.Domain
{
    public interface IChildrenInCircleService
    {
        IEnumerable<int> GetRemovedChildrenInOrderIncludingLastChildAsWinner(int childrenCount, int stepCount);
    }
    class ChildrenInCircleService: IChildrenInCircleService
    {
        public IEnumerable<int> GetRemovedChildrenInOrderIncludingLastChildAsWinner(int childrenCount, int stepCount)
        {

            for (var i = 1; i <= childrenCount; i++)

                yield return FindChild2Remove(childrenCount, stepCount, i);
        }
        int FindChild2Remove(int childrenCount, int stepCount, int sequence)
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
