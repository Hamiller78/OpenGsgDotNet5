using System;

namespace CoreLib.GameLogic
{
    public class GameLoop
    {
        private readonly IServiceProvider _gameServices;

        public GameLoop(IServiceProvider gameServices) =>
            _gameServices = gameServices;

        public void ProcessGameTick(long tickNumber)
        {

        }
    }
}
