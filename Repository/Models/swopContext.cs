using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models
{
    public partial class swopContext : IdentityDbContext<ApplicationUser>
    {
        public swopContext()
        {
        }

        public swopContext(DbContextOptions<swopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Trade> Trades { get; set; } = null!;
        public virtual DbSet<ApplicationUser> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\.\\Kentico;Database=swop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.ToTable("Address");

            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //    entity.Property(e => e.AddressLine1)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AddressLine2)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.City)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Country)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PostCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.State)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Article>(entity =>
            //{
            //    entity.ToTable("Article");

            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Title)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.ToTable("Category");

            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.InverseParent)
            //        .HasForeignKey(d => d.ParentId)
            //        .HasConstraintName("FK_Category_Parent");
            //});

            //modelBuilder.Entity<File>(entity =>
            //{
            //    entity.ToTable("File");

            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //    entity.Property(e => e.Path).IsUnicode(false);

            //    entity.HasOne(d => d.Article)
            //        .WithMany(p => p.Files)
            //        .HasForeignKey(d => d.ArticleId)
            //        .HasConstraintName("FK_File_Article");
            //});

            //modelBuilder.Entity<Offer>(entity =>
            //{
            //    entity.ToTable("Offer");

            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //    entity.HasOne(d => d.Status)
            //        .WithMany(p => p.Offers)
            //        .HasForeignKey(d => d.StatusId)
            //        .HasConstraintName("FK_Offer_Status");
            //});

            //modelBuilder.Entity<Status>(entity =>
            //{
            //    entity.ToTable("Status");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Trade>(entity =>
            //{
            //    entity.ToTable("Trade");

            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //    entity.Property(e => e.Quantity).HasColumnType("text");

            //    entity.HasOne(d => d.Article)
            //        .WithMany(p => p.Trades)
            //        .HasForeignKey(d => d.ArticleId)
            //        .HasConstraintName("FK_Trade_Article");

            //    entity.HasOne(d => d.Offer)
            //        .WithMany(p => p.Trades)
            //        .HasForeignKey(d => d.OfferId)
            //        .HasConstraintName("FK_Trade_Offer");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
