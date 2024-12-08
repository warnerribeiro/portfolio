namespace Core.Repository
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para abstração do repositório de aluno
    /// </summary>
    public interface IRepositoryStudent
    {
        /// <summary>
        /// Adiciona um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Add(Student student);

        /// <summary>
        /// Obtem um aluno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Student Get(int studentId);

        /// <summary>
        /// Obtem todos os alunos conforme os filtros informados de nome, segmento e responsavel.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="segment"></param>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAsync(string name, string segment, string accountable);

        /// <summary>
        /// Obtem todos os alunos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAsync();

        /// <summary>
        /// Remove um aluno
        /// </summary>
        /// <param name="studentId"></param>
        void Remove(int studentId);

        /// <summary>
        /// Atualiza um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Update(Student student);
    }
}