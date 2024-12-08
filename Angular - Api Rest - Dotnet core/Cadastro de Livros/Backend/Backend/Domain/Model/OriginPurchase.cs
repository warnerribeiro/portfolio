
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class OriginPurchase : IEquatable<OriginPurchase?>
    {
        [Required]
        public int OriginPurchaseId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<BookValue> BookValue { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as OriginPurchase);
        }

        public bool Equals(OriginPurchase? other)
        {
            return other is not null &&
                   OriginPurchaseId == other.OriginPurchaseId &&
                   Name == other.Name &&
                   EqualityComparer<ICollection<BookValue>>.Default.Equals(BookValue, other.BookValue);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OriginPurchaseId, Name, BookValue);
        }

        public static bool operator ==(OriginPurchase? left, OriginPurchase? right)
        {
            return EqualityComparer<OriginPurchase>.Default.Equals(left, right);
        }

        public static bool operator !=(OriginPurchase? left, OriginPurchase? right)
        {
            return !(left == right);
        }
    }
}
