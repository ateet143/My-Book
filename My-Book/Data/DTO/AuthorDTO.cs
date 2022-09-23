namespace My_Book.Data.DTO
{
    public class AuthorDTO
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksDTO
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public virtual List<string> BookNames { get; set; }
    }
}
