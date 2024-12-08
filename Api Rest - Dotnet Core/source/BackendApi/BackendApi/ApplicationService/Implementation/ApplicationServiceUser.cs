namespace Web.Api.ApplicationService.Implementation
{
    using Core.Services;
    using Microsoft.Extensions.Configuration;
    using Security;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.Contracts;
    using Web.Api.Parser;

    /// <summary>
    /// Implementação concreta do Servico de aplicacao de Usuario
    /// </summary>
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceDomainUser _serviceDomainUser;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceDomainUser"></param>
        /// <param name="configuration"></param>
        public ApplicationServiceUser(IServiceDomainUser serviceDomainUser, IConfiguration configuration)
        {
            _serviceDomainUser = serviceDomainUser;
            _configuration = configuration;
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int contractReturnUserId)
        {
            _serviceDomainUser.Delete(contractReturnUserId);
        }

        /// <summary>
        /// Editar um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ContractReturnUser Edit(ContractReturnUser contractReturnUser)
        {
            var contractUser = UserParser.Converter(contractReturnUser);

            return UserParser.Converter(_serviceDomainUser.Edit(contractUser));
        }

        /// <summary>
        /// Obter um usuario pelo id
        /// </summary>
        /// <param name="contractReturnUserId"></param>
        /// <returns></returns>
        public ContractReturnUser Get(int contractReturnUserId)
        {
            return UserParser.Converter(_serviceDomainUser.Get(contractReturnUserId));
        }

        /// <summary>
        /// Obter um usuario pelo nome de usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ContractReturnUser Get(string userName)
        {
            return UserParser.Converter(_serviceDomainUser.Get(userName));
        }

        /// <summary>
        /// Obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContractReturnUser>> GetAsync()
        {
            return UserParser.Converter(await _serviceDomainUser.GetAsync());
        }

        /// <summary>
        /// Insere um usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ContractReturnUser Insert(ContractReturnUser contractReturnUser)
        {
            if (string.IsNullOrEmpty(contractReturnUser.UserName) || string.IsNullOrEmpty(contractReturnUser.Password))
                throw new Exception("Nome de usuario ou/e senha não confere.");

            var contractUser = UserParser.Converter(contractReturnUser);

            return UserParser.Converter(_serviceDomainUser.Insert(contractUser));
        }

        /// <summary>
        /// Realiza o login no sistema gerando um token de autenticação
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public dynamic Login(string userName, string password)
        {
            var user = _serviceDomainUser.Get(userName);

            if (user == null)
                throw new Exception("");

            if (user.Password != EncryptPassword.Encrypt(password, user.Salt))
                throw new Exception("");

            var token = ApplicationServiceToken.GenerateToken(user, _configuration);

            user.Password = "";

            return new
            {
                User = user.UserName,
                Token = token
            };
        }
    }
}