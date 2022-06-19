using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Demo.Entities;

#nullable disable

namespace TalentoIT.Context
{
    public partial class TalentoDbContext : DbContext
    {
        public TalentoDbContext()
        {
        }

        public TalentoDbContext(DbContextOptions<TalentoDbContext> options)
            : base(options)
        {
        }

     //   public virtual DbSet<Meal> Meals { get; set; }
     //   public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgrespw");
            }
        }

      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.Property(e => e.MealId).HasDefaultValueSql("nextval('\"meals_idMeal_seq\"'::regclass)");

                entity.Property(e => e.Calories).HasDefaultValueSql("0");

                entity.Property(e => e.Time).HasDefaultValueSql("CURRENT_DATE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("meals_users_iduser_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasDefaultValueSql("nextval('\"users_idUser_seq\"'::regclass)");
            });

            OnModelCreatingPartial(modelBuilder);
        }*/

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
