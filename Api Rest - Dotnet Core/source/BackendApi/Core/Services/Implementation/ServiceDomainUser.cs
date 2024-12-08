namespace Core.Services.Implementation
{
    using Core.Repository;
    using Model.Poco;
    using Security;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementação concreta do serviço de dominio de usuarios
    /// </summary>
    public class ServiceDomainUser : IServiceDomainUser
    {
        private readonly IRepositoryUser _repositoryUser;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositoryUser"></param>
        public ServiceDomainUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        /// <summary>
        /// Deleta um usuario pelo id
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int userId)
        {
            _repositoryUser.Remove(userId);
        }

        /// <summary>
        /// Edita um usuario pelo id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Edit(User user)
        {
            var userDb = Get(user.UserId);

            userDb.Salt = userDb.Salt;
            userDb.Password = EncryptPassword.Encrypt(user.Password, user.Salt);

            var userSaved = _repositoryUser.Update(user);

            if (userSaved != null)
                userSaved.Password = null;

            return userSaved;
        }

        /// <summary>
        /// Obtem um usuario pelo id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User Get(int userId)
        {
            var user = _repositoryUser.Get(userId);

            if (user != null)
                user.Password = null;

            return user;
        }

        /// <summary>
        /// Obtem um usuario pelo nome
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User Get(string userName)
        {
            return _repositoryUser.Get(userName);
        }

        /// <summary>
        /// Obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await _repositoryUser.GetAsync();

            foreach (var item in users)
                if (item != null)
                    item.Password = null;

            return users;
        }

        /// <summary>
        /// Inserir um usuario
        /// </summary>
        /// <param name="userToSave"></param>
        /// <returns></returns>
        public User Insert(User userToSave)
        {
            userToSave.Salt = EncryptPassword.GeneratorSalt();
            userToSave.Password = EncryptPassword.Encrypt(userToSave.Password, userToSave.Salt);

            var userSaved = _repositoryUser.Add(userToSave);

            if (userSaved != null)
                userSaved.Password = null;

            return userSaved;
        }
    }
}