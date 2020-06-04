﻿using CellService.Entities;
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
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    }
                },
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    }
                },
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    }
                },
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    }
                },
                new List<Cell>()
                {
                    new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    },new Cell
                    {
                        Id = Guid.NewGuid(),
                        Color = "#000000"
                    }
                },
            };
        }
    }
}