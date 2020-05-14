namespace RestServer.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ZealandModel : DbContext
    {
        public ZealandModel()
            : base("name=ZealandModel1")
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.brand)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Route)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.fk_carId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.routestart)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.routeend)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Route)
                .HasForeignKey(e => e.fk_routeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Passenger)
                .WithRequired(e => e.Route)
                .HasForeignKey(e => e.fk_routeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Car)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fk_userId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fk_userId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Passenger)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fk_userId)
                .WillCascadeOnDelete(false);
        }
    }
}
