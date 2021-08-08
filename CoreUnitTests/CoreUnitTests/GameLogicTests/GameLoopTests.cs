using CoreLib.GameLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CoreUnitTests
{
    public class GameLoopTests
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();

        public GameLoopTests()
        {
        }

        [Fact]
        public void NormalRun_ProcessGameTick_ExpectedBehaviour()
        {
            Mock<IMovablesProvider> moqMovables = new Mock<IMovablesProvider>();
            Mock<IMovableOnMap> moqMOM1 = new Mock<IMovableOnMap>();
            moqMOM1.Setup(m => m.MoveOneTick());
            Mock<IMovableOnMap> moqMOM2 = new Mock<IMovableOnMap>();
            moqMOM2.Setup(m => m.MoveOneTick());
            List<IMovableOnMap> listOfMOMs = new List<IMovableOnMap>();
            listOfMOMs.Add(moqMOM1.Object);
            listOfMOMs.Add(moqMOM2.Object);

            moqMovables.Setup(m => m.GetMovables())
                              .Returns(listOfMOMs);

            IMovablesProvider mockMovables = moqMovables.Object;
            _serviceCollection.AddSingleton(mockMovables);

            IServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider();

            GameLoop gameLoop = new GameLoop(serviceProvider);
            gameLoop.ProcessGameTick(0);

            moqMOM1.Verify(m => m.MoveOneTick(), Times.Once());
            moqMOM2.Verify(m => m.MoveOneTick(), Times.Once());
        }

    }
}
