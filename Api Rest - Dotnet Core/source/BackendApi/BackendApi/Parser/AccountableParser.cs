namespace Web.Api.Parser
{
    using Model.Poco;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Api.Contracts;

    public static class AccountableParser
    {
        /// <summary>
        /// Converte um modelo de domínio de responsavel em um DTO de responsavel.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static ContractsReturnAccountable Converter(Accountable accountable)
        {
            if (accountable == null)
                return null;

            return new ContractsReturnAccountable
            {
                Id = accountable.AccountableId,
                Name = accountable.Name,
                BirthDate = accountable.BirthDate,
                Email = accountable.Email,
                Kinship = accountable.Kinship,
                StundentId = accountable.StundentId,
                Telephone = accountable.Telephone
            };
        }

        /// <summary>
        /// Converte um DTO de responsavel em um modelo de domínio de responsavel.
        /// </summary>
        /// <param name="contratoRetornoCliente"></param>
        /// <returns></returns>
        public static Accountable Converter(ContractsReturnAccountable contractsReturnAccountable)
        {
            if (contractsReturnAccountable == null)
                return null;

            return new Accountable
            {
                AccountableId = contractsReturnAccountable.Id,
                Name = contractsReturnAccountable.Name,
                Email = contractsReturnAccountable.Email,
                BirthDate = contractsReturnAccountable.BirthDate,
                Kinship = contractsReturnAccountable.Kinship,
                StundentId = contractsReturnAccountable.StundentId,
                Telephone = contractsReturnAccountable.Telephone
            };
        }

        /// <summary>
        /// Converte uma lista de modelos de domínio de responsavel em uma lista de DTOs de responsavel.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static IEnumerable<ContractsReturnAccountable> Converter(IEnumerable<Accountable> accountable)
        {
            if (accountable == null)
                return null;

            return accountable.Select(a => Converter(a));
        }

        /// <summary>
        /// Converte uma lista de DTOs de responsavel em uma lista de modelos de domínio de responsavel.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static ICollection<Accountable> Converter(IEnumerable<ContractsReturnAccountable> accountable)
        {
            if (accountable == null)
                return null;

            return accountable.Select(a => Converter(a)).ToList();
        }
    }
}