using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data
{
    public partial class BookstoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookstoreDbContext()
        {
        }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name="User",
                    NormalizedName = "USER",
                    Id = "4ce23114-07fe-4862-89a7-08bc5fd62781"
                }, 
                new IdentityRole
                {
                    Name="Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "a7fbbd7d-2634-48bf-9304-56197e3edd91"
                }
            );

            var hasher = new PasswordHasher<ApiUser>();

            // Seed users
            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "08373b78-1b9d-4bc6-b5c3-d619eb65eafa",
                    Email = "admin@bookstore.com",
                    NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstore.com",
                    NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null,"P@ssword1")
                },
                new ApiUser
                {
                    Id = "b6649e1e-47ea-4d15-9995-5ccbd163fee9",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstore.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    RoleId = "4ce23114-07fe-4862-89a7-08bc5fd62781",
                    UserId = "b6649e1e-47ea-4d15-9995-5ccbd163fee9",

                },
                new IdentityUserRole<string>
                {
                    RoleId = "a7fbbd7d-2634-48bf-9304-56197e3edd91",
                    UserId = "08373b78-1b9d-4bc6-b5c3-d619eb65eafa",

                }

            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
