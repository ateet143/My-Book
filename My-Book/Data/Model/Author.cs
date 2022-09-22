using System.Text.Json.Serialization;

namespace My_Book.Data.Model
{
    /// <summary>
    /// Author and Book has a manay to many relationship we need to add a joint model
    /// we will add Book_Author as the joint Model for Auther and Book entity.
    /// </summary>
    public class Author
    {

        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation property


        // Author and Book_Author has One to Many relationship
        //Book_Author table has many Authors.
       
        public virtual List<Book_Author> Book_Authors { get; set; } 
    
}
}
