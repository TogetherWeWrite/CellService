using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Exceptions
{
    public class WorldDoesNotContainThisChunkException: Exception
    {
        public WorldDoesNotContainThisChunkException(string title): base("The world: "+title+" does not contain the chunk that you are trying to edit") { }
    }
}
