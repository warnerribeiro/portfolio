namespace Web.Api.ApplicationService.Implementation
{
    using Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.Contracts;
    using Web.Api.Parser;

    /// <summary>
    /// Implementação concreta do Servico de aplicacao de aluno
    /// </summary>
    public class ApplicationServiceStudent : IApplicationServiceStudent
    {
        private IServiceDomainStudent _serviceDomainStudent;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceDomainStudent"></param>
        public ApplicationServiceStudent(IServiceDomainStudent serviceDomainStudent)
        {
            _serviceDomainStudent = serviceDomainStudent;
        }

        /// <summary>
        /// Deleta um aluno
        /// </summary>
        /// <param name="studentId"></param>
        public void Delete(int studentId)
        {
            _serviceDomainStudent.Delete(studentId);
        }

        /// <summary>
        /// Edita um aluno
        /// </summary>
        /// <param name="contractReturnStudent"></param>
        /// <returns></returns>
        public ContractReturnStudent Edit(ContractReturnStudent contractReturnStudent)
        {
            var student = StudentParser.Converter(contractReturnStudent);

            return StudentParser.Converter(_serviceDomainStudent.Edit(student));
        }

        /// <summary>
        /// Obtem um aluno pelo id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public ContractReturnStudent Get(int studentId)
        {
            return StudentParser.Converter(_serviceDomainStudent.Get(studentId));
        }

        /// <summary>
        /// Obtem todos os alunos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContractReturnStudent>> GetAsync()
        {
            return StudentParser.Converter(await _serviceDomainStudent.GetAsync());
        }

        /// <summary>
        /// Obtem todos os alunos pelos filtros de nome, segmento e responsavel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="segment"></param>
        /// <param name="accountable"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContractReturnStudent>> GetAsync(string name, string segment, string accountable)
        {
            return StudentParser.Converter(await _serviceDomainStudent.GetAsync(name, segment, accountable));
        }

        /// <summary>
        /// Inserir um aluno
        /// </summary>
        /// <param name="contractReturnStudent"></param>
        /// <returns></returns>
        public ContractReturnStudent Insert(ContractReturnStudent contractReturnStudent)
        {
            var student = StudentParser.Converter(contractReturnStudent);

            return StudentParser.Converter(_serviceDomainStudent.Insert(student));
        }

        /// <summary>
        /// Valida os dados de um aluno
        /// </summary>
        /// <param name="contractReturnStudent"></param>
        /// <exception cref="Exception"></exception>
        private void ValidationStudent(ContractReturnStudent contractReturnStudent)
        {
            if (contractReturnStudent.Segment == Commom.Segment.fundamental && string.IsNullOrEmpty(contractReturnStudent.Email))
            {
                throw new Exception("Campo de email obrigatorio para ensino fundamental");
            }
        }
    }
}