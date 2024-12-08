namespace Unit.Web.Api.Parser
{
    using global::Web.Api.Contracts;
    using global::Web.Api.Parser;
    using Model.Poco;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class AccountableParserTest
    {
        [Fact]
        public void AccountableToContracts()
        {
            var accountable = new Accountable
            {
                AccountableId = 1,
                BirthDate = new DateTime(2022, 02, 25),
                Email = "email@email.com",
                Kinship = "Parentesco",
                Name = "Responsavel",
                Telephone = "556465465654"
            };

            var accountableParsed = AccountableParser.Converter(accountable);

            Assert.Equal(accountable.AccountableId, accountableParsed.Id);
            Assert.Equal(accountable.Name, accountableParsed.Name);
            Assert.Equal(accountable.Telephone, accountableParsed.Telephone);
            Assert.Equal(accountable.Kinship, accountableParsed.Kinship);
            Assert.Equal(accountable.BirthDate, accountableParsed.BirthDate);
            Assert.Equal(accountable.Email, accountableParsed.Email);
        }

        [Fact]
        public void AccountableToContractsList()
        {
            var accountable = new List<Accountable>
            {
                new Accountable
                {
                    AccountableId = 1,
                    BirthDate = new DateTime(2022, 02, 25),
                    Email = "email@email.com",
                    Kinship = "Parentesco",
                    Name = "Responsavel",
                    Telephone = "556465465654"
                },
                new Accountable
                {
                    AccountableId = 1,
                    BirthDate = new DateTime(2022, 02, 25),
                    Email = "email@email.com",
                    Kinship = "Parentesco",
                    Name = "Responsavel",
                    Telephone = "556465465654"
                },
                new Accountable
                {
                    AccountableId = 1,
                    BirthDate = new DateTime(2022, 02, 25),
                    Email = "email@email.com",
                    Kinship = "Parentesco",
                    Name = "Responsavel",
                    Telephone = "556465465654"
                }
            };

            var accountableParsed = AccountableParser.Converter(accountable);

            Assert.NotEmpty(accountableParsed);
            Assert.Equal(accountable.Count, accountableParsed.ToList().Count);
        }

        [Fact]
        public void ContractsToAccountable()
        {
            var accountable = new ContractsReturnAccountable
            {
                Id = 1,
                BirthDate = new DateTime(2022, 02, 25),
                Email = "email@email.com",
                Kinship = "Parentesco",
                Name = "Responsavel",
                Telephone = "556465465654"
            };

            var accountableParsed = AccountableParser.Converter(accountable);

            Assert.Equal(accountable.Id, accountableParsed.AccountableId);
            Assert.Equal(accountable.Name, accountableParsed.Name);
            Assert.Equal(accountable.Telephone, accountableParsed.Telephone);
            Assert.Equal(accountable.Kinship, accountableParsed.Kinship);
            Assert.Equal(accountable.BirthDate, accountableParsed.BirthDate);
            Assert.Equal(accountable.Email, accountableParsed.Email);
        }
    }
}