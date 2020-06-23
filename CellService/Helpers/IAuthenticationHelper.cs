using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Helpers
{
    public interface IAuthenticationHelper
    {
        public Task<Guid> getUserIdFromToken(string jwt);
    }
}
