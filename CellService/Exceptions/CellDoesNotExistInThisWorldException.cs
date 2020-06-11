using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Exceptions
{
    public class CellDoesNotExistInThisWorldException : Exception
    {
        public CellDoesNotExistInThisWorldException(string title) : base("The cell that you are trying to edit does not exist in this world " + title) { }
    }
}
