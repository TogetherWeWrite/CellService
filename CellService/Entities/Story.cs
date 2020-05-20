using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CellService.Entities
{

    public class Story //Entity from story service which has simple information about the story.
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
