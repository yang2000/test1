using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCoreMVCAll1.Models
{
    public partial class BloggingContext : DbContext
    {
        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                 //               optionsBuilder.UseSqlServer("Server=home1;Database=Blogging;Trusted_Connection=True;");
                                optionsBuilder.UseSqlServer("Data Source=home1;database=Blogging;User ID=sa;Password=Test123");

                //"Server=home1;Database=Blogging;User Id=sa;Password= Test123;";
                //optionsBuilder.UseSqlServer("data source=home1;initial catalog=MyCar;persist security info=True;user id=sa;password=Test123;MultipleActiveResultSets=True;App=EntityFramework;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.BlogId);
            });
        }
    }
}
