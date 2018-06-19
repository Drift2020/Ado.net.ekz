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
        public virtual DbSet<Link_Final> Link_Final { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Right> Rights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("Link_Product_Category").MapLeftKey("CategoryID").MapRightKey("ProductID"));

            modelBuilder.Entity<Family>()
                .HasMany(e => e.People)
                .WithMany(e => e.Families)
                .Map(m => m.ToTable("Link_People_Family").MapLeftKey("FamilyID").MapRightKey("PeopleID"));

            modelBuilder.Entity<Link_Final>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Link_Final)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Link_Final)
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
