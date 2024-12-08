namespace Core.Services.Implementation
{
    using Core.Repository;
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementação concreta do serviço de dominio de aluno
    /// </summary>
    public class ServiceDomainStudent : IServiceDomainStudent
    {
        private readonly IRepositoryStudent _repositoryStudent;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositoryStudent"></param>
        public ServiceDomainStudent(IRepositoryStudent repositoryStudent)
        {
            _repositoryStudent = repositoryStudent;
        }

        /// <summary>
        /// Deleta um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        public void Delete(int studentId)
        {
            _repositoryStudent.Remove(studentId);
        }

        /// <summary>
        /// Edita um estudante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Edit(Student student)
        {
            return _repositoryStudent.Update(student);
        }

        /// <summary>
        /// Obtem um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student Get(int studentId)
        {
            return _repositoryStudent.Get(studentId);
        }

        /// <summary>
        /// Obtem todos os alunos
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Student>> GetAsync()
        {
            return _repositoryStudent.GetAsync();
        }

        /// <summary>
        /// Obtem todos os alunos apartir dos filtros de nome, segmento e responsavel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="segment"></param>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public Task<IEnumerable<Student>> GetAsync(string name, string segment, string accountable)
        {
            return _repositoryStudent.GetAsync(name, segment, accountable);
        }

        /// <summary>
        /// Insere um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Insert(Student student)
        {
            return _repositoryStudent.Add(student);
        }
    }
}