using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CellService.Entities
{

    public class Page //Entity from storysservice which has simple information about the page like from which story it is and what index this page is from the story.
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Story PartOfStory { get; set; }
        public int IndexPage { get; set; }
    }

}
