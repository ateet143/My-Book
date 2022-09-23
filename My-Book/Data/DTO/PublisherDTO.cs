using My_Book.Data.Model;

namespace My_Book.Data.DTO
{
    public class PublisherDTO
    {
        public string Name { get; set; }
    }

    public class PublisherWithBookAndAuthorDTO
    {
        public string PublisherName { get; set; }
      
        public virtual List<BookwithAuthor> Book_Authors_List { get; set; }
    }

    public class BookwithAuthor
    {
        public string Bookname { get; set; }
        public List<string> BookAuthors { get; set; }
      
    }

}
