namespace Web.Api.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para Endpoints de login
    /// </summary>
    [DataContract]
    public class ContractReturnLogin
    {
        [DataMember(Name = "Senha")]
        public string Password { get; set; }

        [DataMember(Name = "Usuario")]
        public string User { get; set; }
    }
}