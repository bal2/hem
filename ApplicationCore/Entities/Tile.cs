using System;

namespace HADU.hem.ApplicationCore.Entities
{
    public class Tile
    {
        public long TileId {get; set;}
        public TileType Type { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int SeatNumber { get; set; }
        public string Text { get; set; }
        public long SeatmapId { get; set; }
        public Seatmap Seatmap { get; set; }
        public Ticket Ticket { get; set; }
    }

    public enum TileType {
        WALL,
        SEAT,
        LOCKEDSEAT,
        OBJECT,
        DOOR,
        EMERGENCYEXIT
    }
}
