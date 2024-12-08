namespace Model.Poco
{
    using System;

    /// <summary>
    ///  Modelo de domínio que representa um Responsavel
    /// </summary>
    public class Accountable
    {
        public int AccountableId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Kinship { get; set; }
        public string Name { get; set; }
        public Student Student { get; set; }
        public int StundentId { get; set; }
        public string Telephone { get; set; }
    }
}