namespace Model.Poco
{
    /// <summary>
    /// Modelo de domínio que representa um usuario
    /// </summary>
    public class User
    {
        public string Password { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}