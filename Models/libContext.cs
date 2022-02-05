using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Models
{
    public partial class libContext : DbContext
    {
        public libContext()
        {
        }

        public libContext(DbContextOptions<libContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SNEHAKSALU\\SQLEXPRESS ; Initial Catalog= lib; Integrated security=True");
            }
        }
*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.Bookid)
                    .HasName("PK__books__8BEA95C5A8679EB5");

                entity.ToTable("books");

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bookname)
                    .HasColumnName("bookname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Publications)
                    .HasColumnName("publications")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.G)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Gid)
                    .HasConstraintName("FK__books__gid__38996AB5");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("PK__genre__DCD80EF8E3F3DFD0");

                entity.ToTable("genre");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Genre1)
                    .HasColumnName("genre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Genre)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__genre__bookid__398D8EEE");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("PK__members__DF5032EC0C4D7A4C");

                entity.ToTable("members");

                entity.Property(e => e.Mid)
                    .HasColumnName("mid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Mname)
                    .HasColumnName("mname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rentid).HasColumnName("rentid");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__members__bookid__3F466844");

                entity.HasOne(d => d.Rent)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.Rentid)
                    .HasConstraintName("FK__members__rentid__403A8C7D");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("rent");

                entity.Property(e => e.Rentid)
                    .HasColumnName("rentid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Dayskept).HasColumnName("dayskept");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Rent)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__rent__bookid__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
