namespace Core.Services
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para abstração do serviço de dominio de usuario
    /// </summary>
    public interface IServiceDomainUser
    {
        /// <summary>
        /// Deleta um usuario pelo id
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);

        /// <summary>
        /// Edita um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Edit(User user);

        /// <summary>
        /// Obtem um usuario pelo id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User Get(int userId);

        /// <summary>
        /// Obtem um usuario pelo nome
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User Get(string userName);

        /// <summary>
        /// Obter todos os usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAsync();

        /// <summary>
        /// Insere um usuarios
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Insert(User user);
    }
}