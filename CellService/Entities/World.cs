using System;
using System.Collections.Generic;
using System.Data;

namespace CellService.Entities
{
    public class World //Entity from world-service, which in the case of cellservice also holds links to cells.
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<List<Guid>> Grid{ get; set; }
    }
}