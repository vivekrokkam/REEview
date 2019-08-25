using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testAPI.Model
{
    public partial class REEviewContext : DbContext
    {
        public REEviewContext()
        {
        }

        public REEviewContext(DbContextOptions<REEviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blogger> Blogger { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:msascriber2019phase2.database.windows.net,1433;Initial Catalog=REEview;Persist Security Info=False;User ID=vivek;Password=1041310442viv!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Blogger>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("PK__Blogger__54379E300609C263");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.WebUrl).IsUnicode(false);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("BlogId");
            });
        }
    }
}
