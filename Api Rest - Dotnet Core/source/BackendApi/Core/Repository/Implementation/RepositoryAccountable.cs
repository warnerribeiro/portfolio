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
    /// Implementação concreta do respositório de Responsavel
    /// </summary>
    public class RepositoryAccountable : IRepositoryAccountable
    {
        private readonly IDbConnection _connection;
        private readonly DataContext _dataContext;
        private readonly DbSet<Accountable> _dbSet;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="context"></param>
        public RepositoryAccountable(IDbConnection connection, DataContext context)
        {
            _connection = connection;
            _dataContext = context;
            _dbSet = _dataContext.Accountable;
        }

        /// <summary>
        /// Adiciona um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public Accountable Add(Accountable accountable)
        {
            _dbSet.Add(accountable);
            _dataContext.SaveChanges();

            return accountable;
        }

        /// <summary>
        /// Obtem um responsavel
        /// </summary>
        /// <param name="accountableId"></param>
        /// <returns></returns>
        public Accountable Get(int accountableId)
        {
            return _dbSet.Find(accountableId);
        }

        /// <summary>
        /// Obtem todos os responsaveis
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Accountable>> GetAsync()
        {
            const string query = @"
                                SELECT
	                                ResponsavelId as AccountableId,
	                                AlunoId as StundentId,
	                                DataNascimento as BirthDate,
	                                Email,
	                                Nome as Name,
	                                Parentesco as Kinship,
	                                Telefone as Telephone
                                FROM
	                                Responsavel";

            var accountables = await _connection.QueryAsync<Accountable>(query).ConfigureAwait(false);

            return accountables.Distinct().ToList();
        }

        /// <summary>
        /// Remove um responsavel
        /// </summary>
        /// <param name="accountableId"></param>
        public void Remove(int accountableId)
        {
            var accountable = _dbSet.Find(accountableId);

            if (accountable != null)
                _dbSet.Remove(accountable);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza um responsavel
        /// </summary>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public Accountable Update(Accountable accountable)
        {
            _dbSet.Update(accountable);
            _dataContext.SaveChanges();

            return accountable;
        }
    }
}