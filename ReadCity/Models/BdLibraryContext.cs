using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadCity.Models;

public partial class BdLibraryContext : DbContext
{
    public BdLibraryContext()
    {
    }

    public BdLibraryContext(DbContextOptions<BdLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<LibraryCard> LibraryCards { get; set; }

    public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bd_library;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameAuthor).HasColumnName("name_author");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Copies).HasColumnName("copies");
            entity.Property(e => e.IdAuthor)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_author");
            entity.Property(e => e.IdGenre)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_genre");
            entity.Property(e => e.IdPublishingHouse)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_publishing_house");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.NameBook).HasColumnName("name_book");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.YearOfPublication).HasColumnName("year_of_publication");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("books_id_author_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .HasConstraintName("books_id_genre_fkey");

            entity.HasOne(d => d.PublishingHouse).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublishingHouse)
                .HasConstraintName("books_id_publishing_house_fkey");
        });

        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_loans_pkey");

            entity.ToTable("book_loans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.IdBooks)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_books");
            entity.Property(e => e.IdLibraryCard)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_library_card");
            entity.Property(e => e.IdStatus)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_status");
            entity.Property(e => e.PlannedReturnDate).HasColumnName("planned_return_date");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");

            entity.HasOne(d => d.Book).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdBooks)
                .HasConstraintName("book_loans_id_books_fkey");

            entity.HasOne(d => d.LibraryCard).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdLibraryCard)
                .HasConstraintName("book_loans_id_library_card_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("book_loans_id_status_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameGenre).HasColumnName("name_genre");
        });

        modelBuilder.Entity<LibraryCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("library_cards_pkey");

            entity.ToTable("library_cards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameLibraryCard).HasColumnName("name_library_card");
        });

        modelBuilder.Entity<PublishingHouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publishing_houses_pkey");

            entity.ToTable("publishing_houses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NamePublishingHouse).HasColumnName("name_publishing_house");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRole).HasColumnName("name_role");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameStatus).HasColumnName("name_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdLibraryCard)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_library_card");
            entity.Property(e => e.IdRole)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.LibraryCard).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdLibraryCard)
                .HasConstraintName("users_id_library_card_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
