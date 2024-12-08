namespace Model.Poco
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Modelo de domínio que representa um Aluno
    /// </summary>
    public class Student
    {
        public Student()
        {
            Accountable = new HashSet<Accountable>();
        }

        public ICollection<Accountable> Accountable { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Segment { get; set; }
        public int StudentId { get; set; }
    }
}