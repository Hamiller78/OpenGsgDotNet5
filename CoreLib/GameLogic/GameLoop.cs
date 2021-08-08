using System;
using System.Collections.Generic;

namespace CoreLib.GameLogic
{
    public class GameLoop
    {
        private readonly IServiceProvider _gameServiceProvider;

        public GameLoop(IServiceProvider gameServiceProvider) =>
            _gameServiceProvider = gameServiceProvider;

        public void ProcessGameTick(long tickNumber)
        {
            ProcessMovements();
        }

        private void ProcessMovements()
        {
            IMovablesProvider movProvider =
                _gameServiceProvider.GetService(typeof(IMovablesProvider)) as IMovablesProvider;
            IEnumerable<IMovableOnMap> listMovables = movProvider.GetMovables();
            if (listMovables == null) return;

            foreach (IMovableOnMap moveableObj in listMovables)
            {
                moveableObj.MoveOneTick();
            }
        }
    }
}
