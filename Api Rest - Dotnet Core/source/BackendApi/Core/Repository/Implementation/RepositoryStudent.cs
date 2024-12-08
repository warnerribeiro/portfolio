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
    /// Implementação concreta do respositório de Aluno
    /// </summary>
    public class RepositoryStudent : IRepositoryStudent
    {
        private readonly IDbConnection _connection;
        private readonly DataContext _dataContext;
        private readonly DbSet<Student> _dbSet;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="connection"></param>
        public RepositoryStudent(DataContext context, IDbConnection connection)
        {
            _dataContext = context;
            _connection = connection;
            _dbSet = _dataContext.Student;
        }

        /// <summary>
        /// Adiciona um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Add(Student student)
        {
            _dbSet.Add(student);
            _dataContext.SaveChanges();

            return student;
        }

        /// <summary>
        /// Obtem um aluno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student Get(int studentId)
        {
            return _dbSet.Include(a => a.Accountable).SingleOrDefault(a => a.StudentId == studentId);
        }

        /// <summary>
        /// Obtem todos os alunos conforme os filtros informados de nome, segmento e responsavel.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="segment"></param>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetAsync(string name, string segment, string accountable)
        {
            const string queryBase = @"
                                    SELECT
	                                    a.AlunoId as StudentId,
	                                    a.DataNascimento as BirthDate,
	                                    a.Email,
	                                    a.ImagemPerfil as ProfilePicture,
	                                    a.Nome as Name,
	                                    a.Segmento as Segment,
	                                    r.ResponsavelId as AccountableId,
	                                    r.Nome as Name,
	                                    r.DataNascimento as BirthDate,
	                                    r.Email,
	                                    r.Parentesco as Kinship,
	                                    r.Telefone as Telephone
                                    FROM
	                                    Aluno a
	                                    left join Responsavel r on a.AlunoId = r.AlunoId";

            var query = queryBase +
                         " WHERE a.Nome LIKE '%" + name +
                         "%' and a.Segmento = '" + segment +
                         "' and r.Nome LIKE '%" + accountable + "%'";

            var studentDictionary = new Dictionary<int, Student>();

            var accountables = await _connection.QueryAsync<Student, Accountable, Student>(query, (a, b) => (StudentXAccountable(studentDictionary, a, b)), splitOn: "AccountableId").ConfigureAwait(false);

            return accountables.Distinct().ToList();
        }

        /// <summary>
        /// Obtem todos os alunos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetAsync()
        {
            const string query = @"	SELECT
		                                a.AlunoId as StudentId,
		                                a.Nome as Name,
		                                a.Email,
		                                a.Segmento as Segment,
		                                a.DataNascimento as BirthDate,
		                                a.ImagemPerfil as ProfilePicture,
		                                r.ResponsavelId as AccountableId,
                                        r.AlunoId as StudentId,
		                                r.Nome as Name,
		                                r.Email,
		                                r.DataNascimento as BirthDate,
		                                r.Parentesco as Kinship,
		                                r.Telefone as Telephone
	                                FROM
		                                Aluno a
		                                inner join Responsavel r on a.AlunoId = r.AlunoId";

            var studentDictionary = new Dictionary<int, Student>();

            var accountables = await _connection.QueryAsync<Student, Accountable, Student>(query, (a, b) => (StudentXAccountable(studentDictionary, a, b)), splitOn: "AccountableId").ConfigureAwait(false);

            return accountables.Distinct().ToList();
        }

        /// <summary>
        /// Remove um aluno
        /// </summary>
        /// <param name="studentId"></param>
        public void Remove(int studentId)
        {
            var student = _dbSet.Find(studentId);

            if (student != null)
                _dbSet.Remove(student);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza um aluno
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Update(Student student)
        {
            AtualizaObjetosAninhados(student);

            _dataContext.SaveChanges();

            return student;
        }

        /// <summary>
        /// Atualizando objetos aninhados do cliente
        /// </summary>
        /// <param name="clientePersistir"></param>
        private void AtualizaObjetosAninhados(Student studentToSave)
        {
            var student = Get(studentToSave.StudentId);

            // Adiciona novos registros
            if (student == null)
            {
                _dataContext.Update(studentToSave);
            }
            // Atualiza registros existentes
            else
            {
                // Atualiza Aluno
                _dataContext.Entry(student).CurrentValues.SetValues(studentToSave);

                // Adiciona ou Atualiza Responsavel
                if (studentToSave.Accountable != null)
                {
                    foreach (var accountable in studentToSave.Accountable)
                    {
                        var contatoExistente = student.Accountable.SingleOrDefault(a => a.AccountableId == accountable.AccountableId);

                        // Adiciona um responsavel que ainda não existe no banco
                        if (contatoExistente == null)
                            student.Accountable.Add(accountable);
                        // Atualiza um responsavel no banco de dados
                        else
                            _dataContext.Entry(contatoExistente).CurrentValues.SetValues(accountable);
                    }
                }

                // Remove Responsavel
                if (student != null)
                {
                    foreach (var accountable in student.Accountable)
                    {
                        if (studentToSave.Accountable.All(a => a.AccountableId != accountable.AccountableId))
                            _dataContext.Accountable.Remove(accountable);
                    }
                }
            }
        }

        /// <summary>
        /// Realiza o relacionamento no Dapper entre Cliente e Produto
        /// </summary>
        /// <param name="studentDictionary"></param>
        /// <param name="student"></param>
        /// <param name="accountable"></param>
        /// <param name="tipoContato"></param>
        /// <returns></returns>
        private Student StudentXAccountable(Dictionary<int, Student> studentDictionary, Student student, Accountable accountable)
        {
            // Realiza tratamento para cliente
            if (!studentDictionary.TryGetValue(student.StudentId, out Student studentEntry))
            {
                studentEntry = student;
                studentEntry.Accountable = new List<Accountable>();
                studentDictionary.Add(studentEntry.StudentId, studentEntry);
            }

            // Preenche a propriedade do Contato
            if (accountable != null)
                studentEntry.Accountable.Add(accountable);

            return studentEntry;
        }
    }
}