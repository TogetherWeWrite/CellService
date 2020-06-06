using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.MqMessages
{
    public class WorldRegisterMessage
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
