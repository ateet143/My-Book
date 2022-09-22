using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace My_Book.Data.Model
{
    /// <summary>
    /// After the creattion of publisher and adding navigation propoerties in Book and Publisher, create the migration in Package Manager console.
    /// Delete the current data in the Book table before updating the database OR put ?(Optional) in PublihserId(foreign key in Book).
    /// </summary>
    public class Publisher
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        //navigtion property
        public virtual List<Book> Books { get; set; }
    }
}
