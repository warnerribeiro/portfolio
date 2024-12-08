using Domain.Model;

namespace Core.Repository
{
    public interface ISubjectRepository
    {
        Subject Get(int sujectId);

        Task<Subject> AddAsync(Subject subject);

        Task<Subject> UpdateAsync(Subject subject);

        Task RemoveAsync(int sujectId);

        Task<IEnumerable<Subject>> GetAsync();
    }
}
