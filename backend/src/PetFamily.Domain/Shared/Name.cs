using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record Name
    {
        public string Value { get; }

        private Name(string value) => Value = value;

        public static Result<Name> Create(string name) =>
            string.IsNullOrWhiteSpace(name)
                ? Result.Failure<Name>("Name cannot be null or empty.")
                : Result.Success(new Name(name));
    }
}
