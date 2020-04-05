using Demo.Library.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Demo.Library.Test.Domain
{
    public class ChildrenInCircleServiceTest
    {
        [Fact]
        public void GetRemovedChildrenInOrderIncludingLastChildAsWinner_return_sequence_of_eliminated_children_with_last_as_Winner()
        {
            //given
            int childrenCount = 5, stepCount = 2;

            //when
            var sut = new ChildrenInCircleService();
            var actualResult = sut.GetRemovedChildrenInOrderIncludingLastChildAsWinner(childrenCount, stepCount);

            //then
            Assert.IsAssignableFrom<IEnumerable<int>>(actualResult);
            Assert.Equal(childrenCount, actualResult.Count());
        }
    }
}
