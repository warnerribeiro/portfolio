
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Author : IEquatable<Author?>
    {
        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Author);
        }

        public bool Equals(Author? other)
        {
            return other is not null &&
                   AuthorId == other.AuthorId &&
                   Name == other.Name &&
                   EqualityComparer<ICollection<BookAuthor>>.Default.Equals(BookAuthor, other.BookAuthor);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AuthorId, Name, BookAuthor);
        }

        public static bool operator ==(Author? left, Author? right)
        {
            return EqualityComparer<Author>.Default.Equals(left, right);
        }

        public static bool operator !=(Author? left, Author? right)
        {
            return !(left == right);
        }
    }
}
