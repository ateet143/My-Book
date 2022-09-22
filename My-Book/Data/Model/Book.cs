using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace My_Book.Data.Model
{
    
    public class Book
    {
       
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public int?  Rate { get; set; }

        public string Genre { get; set; }

        public string CoverUrl { get; set; }

        public DateTime DateAdded { get; set; }

        //Naviation

        public int PublisherId { get; set; }

      
        public Publisher Publisher { get; set; }


        // Book and Book_Author has One to Many relationship
        //Book_Author table has many Books.
        public virtual List<Book_Author> Book_Authors { get; set; }
    }
}
