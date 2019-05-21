using HADU.hem.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HADU.hem.ApplicationCore.Data
{
    public class HemContext : DbContext
    {
        public HemContext(DbContextOptions<HemContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seatmap> Seatmaps { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<Tile> Tile { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>(ConfigureEvent);
        }

        private void ConfigureEvent(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.EventId);
            builder
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
            builder
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }

        private void ConfigurePayment(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.PaymentId);
            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId);
            builder
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
            builder
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }

        private void ConfigureSeatmap(EntityTypeBuilder<Seatmap> builder)
        {
            builder.HasKey(s => s.SeatmapId);
            builder
                .HasOne(s => s.Event)
                .WithMany(e => e.Seatmaps)
                .HasForeignKey(s => s.EventId);
            builder
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
            builder
                .Property(s => s.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }

        private void ConfigureTicket(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.TicketId);
            builder
                .HasOne(t => t.TicketType)
                .WithMany(tt => tt.Tickets)
                .HasForeignKey(t => t.TicketTypeId);
            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);
            builder
                .HasOne(t => t.Payment)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PaymentId);
            builder
                .HasOne(t => t.Tile)
                .WithOne(ti => ti.Ticket)
                .HasForeignKey<Ticket>(t => t.TileId);
            builder
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
            builder
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }

        private void ConfigureTicketType(EntityTypeBuilder<TicketType> builder) {
            builder.HasKey(tt => tt.TicketTypeId);
            builder
                .HasOne(tt => tt.Event)
                .WithMany(e => e.TicketTypes)
                .HasForeignKey(tt => tt.EventId);
        }

        private void ConfigureTile(EntityTypeBuilder<Tile> builder) {
            builder.HasKey(t => t.TileId);
            builder
                .HasOne(t => t.Seatmap)
                .WithMany(s => s.Tiles)
                .HasForeignKey(t => t.SeatmapId);
            builder
                .HasOne(t => t.Ticket)
                .WithOne(ti => ti.Tile)
                .HasForeignKey<Ticket>(t => t.TileId);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder) {
            builder.HasKey(u => u.UserId);
            builder
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
            builder
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
