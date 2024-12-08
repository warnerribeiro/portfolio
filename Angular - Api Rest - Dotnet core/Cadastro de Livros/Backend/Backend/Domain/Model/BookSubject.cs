using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BookSubject : IEquatable<BookSubject?>
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public Subject? Subject { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BookSubject);
        }

        public bool Equals(BookSubject? other)
        {
            return other is not null &&
                   BookId == other.BookId &&
                   SubjectId == other.SubjectId &&
                   EqualityComparer<Book?>.Default.Equals(Book, other.Book) &&
                   EqualityComparer<Subject?>.Default.Equals(Subject, other.Subject);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookId, SubjectId, Book, Subject);
        }

        public static bool operator ==(BookSubject? left, BookSubject? right)
        {
            return EqualityComparer<BookSubject>.Default.Equals(left, right);
        }

        public static bool operator !=(BookSubject? left, BookSubject? right)
        {
            return !(left == right);
        }
    }
}
