using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.VolunteerVO
{
    public record Email
    {
        public string Value { get; }

        private Email(string value) => Value = value;

        public static Result<Email> Create(string email) =>
            string.IsNullOrWhiteSpace(email)
                ? Result.Failure<Email>("Email can't be null or empty.")
                : Result.Success(new Email(email));
    }
}
