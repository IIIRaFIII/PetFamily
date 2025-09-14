using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record Phone
    {
        public string Value { get; }

        private Phone(string value) => Value = value;

        public static Result<Phone> Create(string phone) =>
            string.IsNullOrWhiteSpace(phone)
                ? Result.Failure<Phone>("Phone can't be null or empty.")
                : Result.Success(new Phone(phone));
    }
}
