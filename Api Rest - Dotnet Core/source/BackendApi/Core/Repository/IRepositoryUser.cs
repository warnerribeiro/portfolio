namespace Core.Repository
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para abstração do repositório de usuario
    /// </summary>
    public interface IRepositoryUser
    {
        /// <summary>
        /// Adiciona um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Add(User user);

        /// <summary>
        /// Obtem um usuario pelo seu id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User Get(int userId);

        /// <summary>
        /// Obtem um usuario pelo seu nome
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User Get(string userName);

        /// <summary>
        /// Obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAsync();

        /// <summary>
        /// Remove um usuario pelo seu id
        /// </summary>
        /// <param name="userId"></param>
        void Remove(int userId);

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Update(User user);
    }
}