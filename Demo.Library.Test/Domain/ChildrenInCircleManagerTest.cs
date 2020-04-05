using Demo.Library.Domain;
using Demo.Library.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Demo.Library.Test.Domain
{
    public class ChildrenInCircleManagerTest
    {
        IServiceCollection services;
        public ChildrenInCircleManagerTest()
        {
            services= DependencyService.GetServices();
        }
        [Fact]
        public void GetResult_return_correct_sequence_of_elimination_of_children_and_winner()
        {
            //given
            int childrenCount = 5, stepCount = 2;
            var result = new List<int>() {2,4,1,5,3 };
            var moqChildrenInCicleService = new Mock<IChildrenInCircleService>();
            moqChildrenInCicleService.Setup(m => m.GetRemovedChildrenInOrderIncludingLastChildAsWinner(It.IsAny<int>(), It.IsAny<int>())).Returns(result);

            //when
            var sut = new ChildrenInCircleManager(moqChildrenInCicleService.Object);
            var actualResult = ChildrenInCircleManager.GetResult(childrenCount, stepCount);

            //then
            Assert.IsType<ResultData>(actualResult);
            Assert.Equal(childrenCount - 1, actualResult.RemovedChildrenSequence.Count());
            Assert.Equal(3, actualResult.WinningChild);
        }
        [Fact]
        public void Integration_Test_GetResult_return_correct_sequence_of_elimination_of_children_and_winner()
        {
            //given
            int childrenCount = 5, stepCount = 2;

            var childrenInCicleService = new ChildrenInCircleService();
            //when
            var sut = new ChildrenInCircleManager(childrenInCicleService);
            var actualResult = ChildrenInCircleManager.GetResult(childrenCount, stepCount);

            //then
            Assert.IsType<ResultData>(actualResult);
            Assert.Equal(childrenCount - 1, actualResult.RemovedChildrenSequence.Count());
            Assert.Equal(3, actualResult.WinningChild);
        }
    }
}
