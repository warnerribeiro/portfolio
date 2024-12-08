namespace Web.Api.ApplicationService.Implementation
{
    using Core.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.Contracts;
    using Web.Api.Parser;

    /// <summary>
    /// Implementação concreta do Servico de aplicacao de responsavel
    /// </summary>
    public class ApplicationServiceAccountable : IApplicationServiceAccountable
    {
        private IServiceDomainAccountable _serviceDomainAccountable;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceDomainAccountable"></param>
        public ApplicationServiceAccountable(IServiceDomainAccountable serviceDomainAccountable)
        {
            _serviceDomainAccountable = serviceDomainAccountable;
        }

        /// <summary>
        /// Deleta um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        public void Delete(int accountableId)
        {
            _serviceDomainAccountable.Delete(accountableId);
        }

        /// <summary>
        /// Edita um responsavel
        /// </summary>
        /// <param name="contractsReturnAccountable"></param>
        /// <returns></returns>
        public ContractsReturnAccountable Edit(ContractsReturnAccountable contractsReturnAccountable)
        {
            var accountable = AccountableParser.Converter(contractsReturnAccountable);

            return AccountableParser.Converter(_serviceDomainAccountable.Edit(accountable));
        }

        /// <summary>
        /// Obtem um responsavel pelo id
        /// </summary>
        /// <param name="accountableId"></param>
        /// <returns></returns>
        public ContractsReturnAccountable Get(int accountableId)
        {
            return AccountableParser.Converter(_serviceDomainAccountable.Get(accountableId));
        }

        /// <summary>
        /// Obtem todos os responsaveis
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContractsReturnAccountable>> GetAsync()
        {
            return AccountableParser.Converter(await _serviceDomainAccountable.GetAsync());
        }

        /// <summary>
        /// Insere um responsavel
        /// </summary>
        /// <param name="contractsReturnAccountable"></param>
        /// <returns></returns>
        public ContractsReturnAccountable Insert(ContractsReturnAccountable contractsReturnAccountable)
        {
            var accountable = AccountableParser.Converter(contractsReturnAccountable);

            return AccountableParser.Converter(_serviceDomainAccountable.Insert(accountable));
        }
    }
}