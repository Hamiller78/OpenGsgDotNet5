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
 //           IMovablesProvider movProvider = (IMovablesProvider)_gameServiceProvider.GetService<IMovablesProvider>();
            IMovablesProvider movProvider =
                _gameServiceProvider.GetService(typeof(IMovablesProvider)) as IMovablesProvider;
            IEnumerable<IMovableOnMap> listMovables = movProvider.GetMovables();
            foreach (IMovableOnMap moveableObj in listMovables)
            {
                moveableObj.MoveOneTick();
            }
        }
    }
}
