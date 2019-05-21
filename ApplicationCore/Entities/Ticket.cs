using System;

namespace HADU.hem.ApplicationCore.Entities
{
    public class Ticket
    {
        public long TicketId {get; set;}
        public long Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
        public long TileId { get; set; }
        public Tile Tile { get; set; }

    }
}
