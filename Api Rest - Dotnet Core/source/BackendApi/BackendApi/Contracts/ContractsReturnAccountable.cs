namespace Web.Api.Contracts
{
    using Model.Poco;
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para Endpoints de responsavel
    /// </summary>
    [DataContract]
    public class ContractsReturnAccountable
    {
        [DataMember(Name = "dataNascimento")]
        public DateTime BirthDate { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "parentesco")]
        public string Kinship { get; set; }

        [DataMember(Name = "nome")]
        public string Name { get; set; }

        [DataMember(Name = "aluno")]
        public Student Student { get; set; }

        [DataMember(Name = "alunoId")]
        public int StundentId { get; set; }
        [DataMember(Name = "telefone")]
        public string Telephone { get; set; }
    }
}