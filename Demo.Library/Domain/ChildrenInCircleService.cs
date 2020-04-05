using System.Collections.Generic;
using System;

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
            if (childrenCount < 1 || stepCount < 1)
                return 0;
            var child2BeRemoved = default(int);
            try
            {
                child2BeRemoved = stepCount * sequence;

                while (child2BeRemoved > childrenCount)
                {
                    var temp = (child2BeRemoved - childrenCount - 1) / (stepCount - 1);

                    child2BeRemoved = temp + child2BeRemoved - childrenCount;

                }
            }
            catch (Exception)
            {
                // log //throw;
            }
            return child2BeRemoved;
        }
    }
}
