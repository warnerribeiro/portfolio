namespace Core.Services
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para abstração do serviço de dominio do responsavel
    /// </summary>
    public interface IServiceDomainAccountable
    {
        /// <summary>
        /// Deleta um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        void Delete(int accountableId);

        /// <summary>
        /// Edita um responsavel pelo id
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Accountable Edit(Accountable accountable);

        /// <summary>
        /// Obtem um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        /// <returns></returns>
        Accountable Get(int accountableId);

        /// <summary>
        /// Obtem todos os responsaveis
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Accountable>> GetAsync();

        /// <summary>
        /// Insere um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Accountable Insert(Accountable accountable);
    }
}