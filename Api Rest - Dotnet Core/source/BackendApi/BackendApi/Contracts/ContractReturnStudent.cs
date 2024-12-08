namespace Web.Api.Contracts
{
    using Commom;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para Endpoints de aluno
    /// </summary>
    [DataContract]
    public class ContractReturnStudent
    {
        [DataMember(Name = "responsavel")]
        public IEnumerable<ContractsReturnAccountable> Accountable { get; set; }

        [DataMember(Name = "dataNascimento")]
        public DateTime BirthDate { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember]
        public int Id { get; set; }
        [DataMember(Name = "nome")]
        public string Name { get; set; }

        [DataMember(Name = "imagemPerfil")]
        public byte[] ProfilePicture { get; set; }
        [DataMember(Name = "segmento")]
        public Segment Segment { get; set; }
    }
}