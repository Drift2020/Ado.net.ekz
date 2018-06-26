namespace Cash.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CashDB : DbContext
    {
        public CashDB()
            : base("name=CashDB")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Final> Finals { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Right> Rights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("Category_Link_Product").MapLeftKey("CategoryID").MapRightKey("ProductID"));

            modelBuilder.Entity<Family>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Family)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Final>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Person>()
                .Property(e => e.Secret_word)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Finals)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Finals)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Right>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Right)
                .HasForeignKey(e => e.RightsID)
                .WillCascadeOnDelete(false);
        }
    }
}
