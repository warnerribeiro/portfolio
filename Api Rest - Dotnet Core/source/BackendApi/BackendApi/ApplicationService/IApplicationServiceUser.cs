namespace Web.Api.ApplicationService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.Contracts;

    /// <summary>
    /// Interface para abstração de serviço de aplicação de usuario
    /// </summary>
    public interface IApplicationServiceUser
    {
        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);

        /// <summary>
        /// Editar um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ContractReturnUser Edit(ContractReturnUser user);

        /// <summary>
        /// Obter um usuario pelo id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ContractReturnUser Get(int userId);

        /// <summary>
        /// Obter um usuario pelo nome de usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ContractReturnUser Get(string userName);

        /// <summary>
        /// Obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContractReturnUser>> GetAsync();

        /// <summary>
        /// Insere um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ContractReturnUser Insert(ContractReturnUser user);

        /// <summary>
        /// Realiza o login no sistema gerando um token de autenticação
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        dynamic Login(string userName, string password);
    }
}