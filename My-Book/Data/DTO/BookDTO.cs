using My_Book.Data.Model;

namespace My_Book.Data.DTO
{
    //BookDTO is created so that we can prevent over-post attack, here we will hide Id and DateAdded field.
    public class BookDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string CoverUrl { get; set; }


        public int PublisherId { get; set; }

        public virtual List<int> AuthorsIds { get; set; }
    }
}
