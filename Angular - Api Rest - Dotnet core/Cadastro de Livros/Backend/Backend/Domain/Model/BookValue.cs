using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BookValue : IEquatable<BookValue?>
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int OriginPurchaseId { get; set; }

        [Required]
        public decimal Value { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public OriginPurchase? OriginPurchase { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BookValue);
        }

        public bool Equals(BookValue? other)
        {
            return other is not null &&
                   BookId == other.BookId &&
                   OriginPurchaseId == other.OriginPurchaseId &&
                   Value == other.Value &&
                   EqualityComparer<Book?>.Default.Equals(Book, other.Book) &&
                   EqualityComparer<OriginPurchase?>.Default.Equals(OriginPurchase, other.OriginPurchase);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookId, OriginPurchaseId, Value, Book, OriginPurchase);
        }

        public static bool operator ==(BookValue? left, BookValue? right)
        {
            return EqualityComparer<BookValue>.Default.Equals(left, right);
        }

        public static bool operator !=(BookValue? left, BookValue? right)
        {
            return !(left == right);
        }
    }
}
