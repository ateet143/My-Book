using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace My_Book.Data.Model
{

    // Database context is a bridge between your entity class(c sharp) and the database table(SQL)
    // To add Database context we need to install EntityFrameworkCore package.
    public class AppDbContext: DbContext
    {

       public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

       
        /// Relationship between all three tables needs to also be configured using the fluent API for the entity for a more core to be able to map it successfully.
        /// we are going to override the OnModelCreating method 
        ///It takes as a parameter, the modelbuilder 
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relation to be defined over the Book_Author table.
            //It has One Book With Many Book_Authors
            //Has foreignKey as BookID
            modelBuilder.Entity<Book_Author>()     // modelBuilder for the Entity Book_Author
               .HasOne(b => b.Book)
               .WithMany(ba => ba.Book_Authors)
               .HasForeignKey(b => b.BookId);

            //It has One Author With Many Book_Authors
            //Has foreignKey as AuthorID
            modelBuilder.Entity<Book_Author>()
              .HasOne(b => b.Author)
              .WithMany(ba => ba.Book_Authors)
              .HasForeignKey(b => b.AuthorId);
        }

      
        /// Table name for the c Sharp class
        /// SQL table name will be changes or named according to the Names given here
        /// Tables names Books, Authors and Books_Authors are can be access.
        public DbSet<Book> Books { get; set; }    //Book class Map to Books table in SQL
        public DbSet<Author> Authors { get; set; }    //Author class Map to Authors table in SQL
        public DbSet<Book_Author> Books_Authors { get; set; }   //Book_Author class map to Books_Authors
        public DbSet<Publisher> Publishers { get; set; }

    }
}
