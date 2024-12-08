using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BookAuthor : IEquatable<BookAuthor?>
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public Author? Author { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BookAuthor);
        }

        public bool Equals(BookAuthor? other)
        {
            return other is not null &&
                   BookId == other.BookId &&
                   AuthorId == other.AuthorId &&
                   EqualityComparer<Book?>.Default.Equals(Book, other.Book) &&
                   EqualityComparer<Author?>.Default.Equals(Author, other.Author);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookId, AuthorId, Book, Author);
        }

        public static bool operator ==(BookAuthor? left, BookAuthor? right)
        {
            return EqualityComparer<BookAuthor>.Default.Equals(left, right);
        }

        public static bool operator !=(BookAuthor? left, BookAuthor? right)
        {
            return !(left == right);
        }
    }
}
