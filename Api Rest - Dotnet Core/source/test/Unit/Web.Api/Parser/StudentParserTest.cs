namespace Unit.Web.Api.Parser
{
    using Commom;
    using EnumsNET;
    using global::Web.Api.Contracts;
    using global::Web.Api.Parser;
    using Model.Poco;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class StudentParserTest
    {
        [Fact]
        public void ContractToStudentTest()
        {
            var students = new ContractReturnStudent
            {
                Id = 1,
                Name = "Aluno",
                BirthDate = new DateTime(2022, 02, 18),
                Email = "email@email.com",
                Segment = Segment.infantile,
                ProfilePicture = new byte[100]
            };

            var studentParsed = StudentParser.Converter(students);

            Assert.Equal(students.Name, studentParsed.Name);
            Assert.Equal(students.Segment, studentParsed.Segment.GetEnum());
            Assert.Equal(students.Email, studentParsed.Email);
            Assert.Equal(students.BirthDate, studentParsed.BirthDate);
            Assert.Equal(students.ProfilePicture, studentParsed.ProfilePicture);
            Assert.Equal(students.Id, studentParsed.StudentId);
        }

        [Fact]
        public void StudentToContractListTest()
        {
            var students = new List<Student>
            {
               new Student
               {
                    StudentId = 1,
                    Name = "Aluno",
                    BirthDate = new DateTime(2022, 02, 18),
                    Email = "email@email.com",
                    Segment = "Fundamental",
                    ProfilePicture = new byte[100]
               },
               new Student
               {
                    StudentId = 1,
                    Name = "Aluno",
                    BirthDate = new DateTime(2022, 02, 18),
                    Email = "email@email.com",
                    Segment = "Fundamental",
                    ProfilePicture = new byte[100]
               },
               new Student
               {
                    StudentId = 1,
                    Name = "Aluno",
                    BirthDate = new DateTime(2022, 02, 18),
                    Email = "email@email.com",
                    Segment = "Fundamental",
                    ProfilePicture = new byte[100]
               }
            };

            var studentParsed = StudentParser.Converter(students);

            Assert.NotEmpty(studentParsed);
            Assert.Equal(students.Count, studentParsed.ToList().Count);
        }

        [Fact]
        public void StudentToContractTest()
        {
            var students = new Student
            {
                StudentId = 1,
                Name = "Aluno",
                BirthDate = new DateTime(2022, 02, 18),
                Email = "email@email.com",
                Segment = "Fundamental",
                ProfilePicture = new byte[100]
            };

            var studentParsed = StudentParser.Converter(students);

            Assert.Equal(students.Name, studentParsed.Name);
            Assert.Equal(students.Segment, studentParsed.Segment.AsString(EnumFormat.Description));
            Assert.Equal(students.Email, studentParsed.Email);
            Assert.Equal(students.BirthDate, studentParsed.BirthDate);
            Assert.Equal(students.ProfilePicture, studentParsed.ProfilePicture);
            Assert.Equal(students.StudentId, studentParsed.Id);
        }
    }
}