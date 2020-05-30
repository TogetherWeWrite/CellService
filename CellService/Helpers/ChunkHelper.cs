using CellService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Helpers
{
    public class ChunkHelper : IChunkHelper
    {
        public async Task<List<List<Cell>>> GetStandardChunkGrid(string name)
        {
            return new List<List<Cell>>()
            {
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "left-top" + name,
                        Color = "#000000"
                    },
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "middle-top" + name,
                        Color = "#ffffff"
                    },
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "right-top" + name,
                        Color = "#000000"
                    }
                },
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "left-middle" + name,
                        Color = "#ffffff"
                    },
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "middle-middle"+ name,
                        Color = "#000000"
                    },
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "right-middle"+ name,
                        Color = "#ffffff"
                    }
                },
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "left-bottom" + name,
                        Color = "#000000"
                    },
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "middle-bottom"+ name,
                        Color = "#ffffff"
                    },
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        AttachedPages = new List<Page>(),
                        CellName = "right-bottom"+ name,
                        Color = "#000000"
                    }
                }
            };
        }
    }
}
