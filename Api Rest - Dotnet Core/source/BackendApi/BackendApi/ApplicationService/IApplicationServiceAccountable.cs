namespace Web.Api.ApplicationService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.Contracts;

    /// <summary>
    /// Interface para abstração de serviço de aplicação de responsavel
    /// </summary>
    public interface IApplicationServiceAccountable
    {
        /// <summary>
        /// Deleta um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        void Delete(int accountableId);

        /// <summary>
        /// Editar um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        ContractsReturnAccountable Edit(ContractsReturnAccountable accountable);

        /// <summary>
        /// Obtem um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        /// <returns></returns>
        ContractsReturnAccountable Get(int accountableId);

        /// <summary>
        /// Obtem totos os responsaveis
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContractsReturnAccountable>> GetAsync();
        /// <summary>
        /// Insere um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        ContractsReturnAccountable Insert(ContractsReturnAccountable accountable);
    }
}