namespace Web.Api.Parser
{
    using Commom;
    using EnumsNET;
    using Model.Poco;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Api.Contracts;

    public static class StudentParser
    {
        /// <summary>
        /// Converte um modelo de domínio de aluno em um DTO de aluno.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static ContractReturnStudent Converter(Student student)
        {
            if (student == null)
                return null;

            return new ContractReturnStudent
            {
                Id = student.StudentId,
                Name = student.Name,
                BirthDate = student.BirthDate,
                Email = student.Email,
                Segment = student.Segment.GetEnum(),
                ProfilePicture = student.ProfilePicture,
                Accountable = AccountableParser.Converter(student.Accountable)
            };
        }

        /// <summary>
        /// Converte um DTO de aluno em um modelo de domínio de aluno.
        /// </summary>
        /// <param name="contratoRetornoCliente"></param>
        /// <returns></returns>
        public static Student Converter(ContractReturnStudent contractsReturnStudent)
        {
            if (contractsReturnStudent == null)
                return null;

            return new Student
            {
                StudentId = contractsReturnStudent.Id,
                Name = contractsReturnStudent.Name,
                Email = contractsReturnStudent.Email,
                BirthDate = contractsReturnStudent.BirthDate,
                Segment = contractsReturnStudent.Segment.AsString(EnumFormat.Description),
                ProfilePicture = contractsReturnStudent.ProfilePicture,
                Accountable = AccountableParser.Converter(contractsReturnStudent.Accountable)
            };
        }

        /// <summary>
        /// Converte uma lista de modelos de domínio de aluno em uma lista de DTOs de aluno.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static IEnumerable<ContractReturnStudent> Converter(IEnumerable<Student> accountable)
        {
            return accountable.Select(a => Converter(a));
        }
    }
}