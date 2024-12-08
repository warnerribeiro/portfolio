
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Subject : IEquatable<Subject?>
    {
        public Subject()
        {
            BookSubject = new HashSet<BookSubject>();
        }

        public int SubjectId { get; set; }

        [Required]
        [StringLength(20)]
        public string Description { get; set; }

        public ICollection<BookSubject> BookSubject { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Subject);
        }

        public bool Equals(Subject? other)
        {
            return other is not null &&
                   SubjectId == other.SubjectId &&
                   Description == other.Description &&
                   EqualityComparer<ICollection<BookSubject>>.Default.Equals(BookSubject, other.BookSubject);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubjectId, Description, BookSubject);
        }

        public static bool operator ==(Subject? left, Subject? right)
        {
            return EqualityComparer<Subject>.Default.Equals(left, right);
        }

        public static bool operator !=(Subject? left, Subject? right)
        {
            return !(left == right);
        }
    }
}
