namespace Core.Repository.Implementation
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using Model.Poco;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementação concreta do respositório de Usuario
    /// </summary>
    public class RepositoryUser : IRepositoryUser
    {
        private readonly IDbConnection _connection;
        private readonly DataContext _dataContext;
        private readonly DbSet<User> _dbSet;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="dataContext"></param>
        public RepositoryUser(IDbConnection connection, DataContext dataContext)
        {
            _connection = connection;
            _dataContext = dataContext;
            _dbSet = _dataContext.User;
        }

        /// <summary>
        /// Adiciona um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Add(User user)
        {
            _dbSet.Add(user);
            _dataContext.SaveChanges();

            return user;
        }

        /// <summary>
        /// Obtem um usuario pelo seu id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User Get(int userId)
        {
            return _dbSet.SingleOrDefault(a => a.UserId == userId);
        }

        /// <summary>
        /// Obtem um usuario pelo seu nome
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User Get(string userName)
        {
            return _dbSet.SingleOrDefault(a => a.UserName == userName);
        }

        /// <summary>
        /// Obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAsync()
        {
            const string query = @"
                                    SELECT
	                                    UsuarioId as UserId,
	                                    NomeUsuario as UserName,
	                                    Senha as Password,
	                                    Salt,
	                                    Papel as Role
                                    FROM
	                                    Usuario";

            var accountables = await _connection.QueryAsync<User>(query).ConfigureAwait(false);

            return accountables.Distinct().ToList();
        }

        /// <summary>
        /// Remove um usuario pelo seu id
        /// </summary>
        /// <param name="userId"></param>
        public void Remove(int userId)
        {
            var user = _dbSet.Find(userId);

            if (user != null)
                _dbSet.Remove(user);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Update(User user)
        {
            _dbSet.Update(user);
            _dataContext.SaveChanges();

            return user;
        }
    }
}