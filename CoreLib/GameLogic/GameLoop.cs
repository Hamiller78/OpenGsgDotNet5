using System;
using System.Collections.Generic;

namespace CoreLib.GameLogic
{
    public class GameLoop
    {
        private readonly IServiceProvider _gameServices;

        public GameLoop(IServiceProvider gameServices) =>
            _gameServices = gameServices;

        public void ProcessGameTick(long tickNumber)
        {
            ProcessMovements();
        }

        private ProcessMovements()
        {
            IEnumerable<IMovableOnMap> listMovables = _gameServices.GetService<MovablesContainer>();
            foreach (IMovableOnMap moveableObj in listMovables)
            {
                moveableObj.MoveOneTick();
            }
        }
    }
}
