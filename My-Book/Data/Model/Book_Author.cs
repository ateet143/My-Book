using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Reflection.Metadata.BlobBuilder;
using System.Data;
using System.Drawing;
using System.Threading;

namespace My_Book.Data.Model
{
    public class Book_Author
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }


        /*  Since the relationship between the author and the book model is a many to many relationship in the navigation 
            properties do not add the book as a navigation property, but will add the book author.And the reason for that is because the relation between the book table and the author table will be 
            stored in the Book_Author table.So, for example, let us say on the book table you have three books book one, two, three, and on the right side you have three authors.
            Now in the book 1, for example, is written just by the author 1, you two have a role in the Book_Author table with the book Id 1 do want and the author id 1 
            is one if let's say the second book with the id 2 is written by the author 2 and 3.Then in the Book_Author table, you'd have two rows with the book id 2 and the author id 2 and 3.
            So we can see here that the relation is really divided from the book author.
        */


        /*
         Book table                             Book_Author                          Author
         BookId: 1                           B_A:1   B:1 A:1                        AuthorID: 1
         BookId:2                            B_A:2   B:2 A:2                        AuthorID: 2
         BookId: 3                           B_A:3   B:2 A:3                        AuthorID: 3
                                             B_A:4   B:3 A:1 
                                             B_A:5   B:3 A:2 
                                             B_A:6   B:3 A:3 
        */


    }
}
