namespace RestServer.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ZealandModel : DbContext
    {
        public ZealandModel()
            : base("name=ZealandModel")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Forum> Fora { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                .Property(e => e.nummerplade)
                .IsUnicode(false);

            //modelBuilder.Entity<Car>()
            //    .HasMany(e => e.Routes)
            //    .WithRequired(e => e.Car)
            //    .HasForeignKey(e => e.fk_carId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.comment1)
                .IsUnicode(false);

            modelBuilder.Entity<Forum>()
                .Property(e => e.header)
                .IsUnicode(false);

            modelBuilder.Entity<Forum>()
                .Property(e => e.content)
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

            //modelBuilder.Entity<Route>()
            //    .HasMany(e => e.Comments)
            //    .WithRequired(e => e.Route)
            //    .HasForeignKey(e => e.fk_routeId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Route>()
            //    .HasMany(e => e.Passengers)
            //    .WithRequired(e => e.Route)
            //    .HasForeignKey(e => e.fk_routeId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.tmpPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.token)
                .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Cars)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.fk_userId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Comments)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.fk_userId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Fora)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.fk_userId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Passengers)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.fk_userId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
