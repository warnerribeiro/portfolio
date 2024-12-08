
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Book : IEquatable<Book?>
    {
        public Book()
        {
            BookAuthor = new HashSet<BookAuthor>();
            BookSubject = new HashSet<BookSubject>();
            BookValue = new HashSet<BookValue>();
        }

        [Required]
        public int BookId { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }

        [Required]
        [StringLength(40)]
        public string Publisher { get; set; }

        [Required]
        public int Edition { get; set; }

        [Required]
        [StringLength(4)]
        public string YearOfPublication { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }

        public ICollection<BookSubject> BookSubject { get; set; }

        public ICollection<BookValue> BookValue { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Book);
        }

        public bool Equals(Book? other)
        {
            return other is not null &&
                   BookId == other.BookId &&
                   Title == other.Title &&
                   Publisher == other.Publisher &&
                   Edition == other.Edition &&
                   YearOfPublication == other.YearOfPublication &&
                   EqualityComparer<ICollection<BookAuthor>>.Default.Equals(BookAuthor, other.BookAuthor) &&
                   EqualityComparer<ICollection<BookSubject>>.Default.Equals(BookSubject, other.BookSubject) &&
                   EqualityComparer<ICollection<BookValue>>.Default.Equals(BookValue, other.BookValue);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookId, Title, Publisher, Edition, YearOfPublication, BookAuthor, BookSubject, BookValue);
        }

        public static bool operator ==(Book? left, Book? right)
        {
            return EqualityComparer<Book>.Default.Equals(left, right);
        }

        public static bool operator !=(Book? left, Book? right)
        {
            return !(left == right);
        }
    }
}
