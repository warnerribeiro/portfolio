namespace Web.Api.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para Endpoints de usuario
    /// </summary>
    [DataContract]
    public class ContractReturnUser
    {
        [DataMember(Name = "Senha")]
        public string Password { get; set; }

        [DataMember(Name = "Papel")]
        public string Role { get; set; }

        [DataMember(Name = "Sal")]
        public string Salt { get; set; }

        [DataMember(Name = "UsuarioId")]
        public int UserId { get; set; }

        [DataMember(Name = "UsuarioNome")]
        public string UserName { get; set; }
    }
}