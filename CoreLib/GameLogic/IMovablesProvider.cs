using System;
using System.Collections.Generic;

namespace CoreLib.GameLogic
{

    public interface IMovablesProvider
    {
        IEnumerable<IMovableOnMap> GetMovables();
    }
}
