namespace Core.Repository
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para abstração do repositório de responsavel
    /// </summary>
    public interface IRepositoryAccountable
    {
        /// <summary>
        /// Adiciona um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Accountable Add(Accountable accountable);

        /// <summary>
        /// Obtem um responsavel
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
        /// Remove um responsavel
        /// </summary>
        /// <param name="accountableId"></param>
        void Remove(int accountableId);

        /// <summary>
        /// Atualiza um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        Accountable Update(Accountable accountable);
    }
}