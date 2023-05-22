using SQLite;


namespace BooksXamarin.Models
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool wasRead { get; set; }
        public string Commentary { get; set; }
    }
}
