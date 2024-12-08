namespace Core.Services.Implementation
{
    using Core.Repository;
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementação concreta do serviço de dominio de responsavel
    /// </summary>
    public class ServiceDomainAccountable : IServiceDomainAccountable
    {
        private readonly IRepositoryAccountable _repositoryAccountable;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositoryAccountable"></param>
        public ServiceDomainAccountable(IRepositoryAccountable repositoryAccountable)
        {
            _repositoryAccountable = repositoryAccountable;
        }

        /// <summary>
        /// Deleta um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        public void Delete(int accountableId)
        {
            _repositoryAccountable.Remove(accountableId);
        }

        /// <summary>
        /// Editar um responsavel pelo id
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public Accountable Edit(Accountable accountable)
        {
            return _repositoryAccountable.Update(accountable);
        }

        /// <summary>
        /// Obtem um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        /// <returns></returns>
        public Accountable Get(int accountableId)
        {
            return _repositoryAccountable.Get(accountableId);
        }

        /// <summary>
        /// Obtem todos os responsavel
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Accountable>> GetAsync()
        {
            return _repositoryAccountable.GetAsync();
        }

        /// <summary>
        /// Insere um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public Accountable Insert(Accountable accountable)
        {
            return _repositoryAccountable.Add(accountable);
        }
    }
}