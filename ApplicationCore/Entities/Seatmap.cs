using System;
using System.Collections.Generic;

namespace HADU.hem.ApplicationCore.Entities
{
    public class Seatmap
    {
        public long SeatmapId {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; }
        public List<Tile> Tiles { get; set; }
    }
}
