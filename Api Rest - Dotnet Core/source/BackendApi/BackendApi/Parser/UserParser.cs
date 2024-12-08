namespace Web.Api.Parser
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Api.Contracts;

    public static class UserParser
    {
        /// <summary>
        /// Converte um modelo de domínio de usuario em um DTO de usuario.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static ContractReturnUser Converter(User user)
        {
            if (user == null)
                return null;

            return new ContractReturnUser
            {
                UserId = user.UserId,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName
            };
        }

        /// <summary>
        /// Converte um DTO de usuario em um modelo de domínio de usuario.
        /// </summary>
        /// <param name="contratoRetornoCliente"></param>
        /// <returns></returns>
        public static User Converter(ContractReturnUser contractsReturnStudent)
        {
            if (contractsReturnStudent == null)
                return null;

            return new User
            {
                UserId = contractsReturnStudent.UserId,
                Password = contractsReturnStudent.Password,
                Role = contractsReturnStudent.Role,
                UserName = contractsReturnStudent.UserName
            };
        }

        /// <summary>
        /// Converte uma lista de modelos de domínio de usuario em uma lista de DTOs de usuario.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static IEnumerable<ContractReturnUser> Converter(IEnumerable<User> accountable)
        {
            return accountable.Select(a => Converter(a));
        }
    }
}