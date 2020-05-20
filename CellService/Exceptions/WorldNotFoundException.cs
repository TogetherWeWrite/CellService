using System;

namespace Exceptions
{
    public class WorldNotFoundException : Exception
    {
        public WorldNotFoundException(string worldTitle) : base("The world with the Title: " + worldTitle + " could not be found.") { }
        public WorldNotFoundException(Guid id) : base("The world with the id: " + id+ " could not be found.") { }
    }
}