using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.VolunteerVO
{
    public class FullName
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Surname { get; }

        private FullName(string firstName, string lastName, string surname) =>
            (FirstName, LastName, Surname) = (firstName, lastName, surname);

        public static Result<FullName> Create(string firstName, string lastName, string surname) =>
            string.IsNullOrWhiteSpace(firstName) ? Result.Failure<FullName>("FirstName can't be null or empty.") :
            string.IsNullOrWhiteSpace(lastName) ? Result.Failure<FullName>("LastName can't be null or empty.") :
            string.IsNullOrWhiteSpace(surname) ? Result.Failure<FullName>("Surname can't be null or empty.") :
                Result.Success(new FullName(firstName, lastName, surname));
    }
}
