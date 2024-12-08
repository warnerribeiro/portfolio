namespace Web.Api.ApplicationService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.Contracts;

    /// <summary>
    /// Interface para abstração de serviço de aplicação de aluno
    /// </summary>
    public interface IApplicationServiceStudent
    {
        /// <summary>
        /// Remove um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        void Delete(int studentId);

        /// <summary>
        /// Edita um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        ContractReturnStudent Edit(ContractReturnStudent student);

        /// <summary>
        /// Obtem um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        ContractReturnStudent Get(int studentId);

        /// <summary>
        /// Obtem todos os alunos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContractReturnStudent>> GetAsync();

        /// <summary>
        /// Obtem todos os alunos pelo filtro de nome, segmento e responsavel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="segment"></param>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Task<IEnumerable<ContractReturnStudent>> GetAsync(string name, string segment, string accountable);

        /// <summary>
        /// Insere um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        ContractReturnStudent Insert(ContractReturnStudent student);
    }
}