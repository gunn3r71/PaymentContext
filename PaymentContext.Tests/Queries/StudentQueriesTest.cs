using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using FluentAssertions;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Queries
{
    public class StudentQueriesTest
    {
        private List<Student> _students = new List<Student>();

        public StudentQueriesTest()
        {
            GenerateStudents();
            GenerateStaticStudent();
        }


        [Fact]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var student = _students.AsQueryable().Where(StudentQueries.GetStudent("51566495805")).FirstOrDefault();

            student.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnSuccessWhenDocumentExists()
        {
            var student = _students.AsQueryable().Where(StudentQueries.GetStudent("36849153005")).FirstOrDefault();

            student.Should().BeOfType<Student>();
        }

        private void GenerateStudents()
        {
            var students = new Faker<Student>("pt_BR")
                .CustomInstantiator( i => new Student
                (
                    new Name(i.Person.FirstName, i.Person.LastName),
                    new Document($"3684915300{new Random().Next(1,9)}", EDocumentType.CPF),
                    new Email(i.Person.Email)
                )).Generate(9);

            _students.AddRange(students);
        }

        private void GenerateStaticStudent()
        {
            var name = new Name(firstName: "Axl", lastName: "Rose");
            var document = new Document(number: "36849153005", type: EDocumentType.CPF);
            var email = new Email(address: "axl@contatognr.com");
            var student = new Student(name, document, email);

            _students.Add(student);
        }
       
    }
}
