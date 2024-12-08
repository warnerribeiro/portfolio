namespace Core.Services
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para abstração do serviço de dominio de aluno
    /// </summary>
    public interface IServiceDomainStudent
    {
        /// <summary>
        /// Deleta um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        void Delete(int studentId);

        /// <summary>
        /// Edita um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Edit(Student student);

        /// <summary>
        /// Obtem um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Student Get(int studentId);

        /// <summary>
        /// Obtem todos os alunos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAsync();

        /// <summary>
        /// Obtem todos os alunos apartir dos filtros definidos
        /// </summary>
        /// <param name="name"></param>
        /// <param name="segment"></param>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAsync(string name, string segment, string accountable);

        /// <summary>
        /// Insere um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Insert(Student student);
    }
}