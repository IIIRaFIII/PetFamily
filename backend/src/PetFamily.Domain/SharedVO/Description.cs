using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record Description
    {
        public string Value { get; }

        private Description(string value) => Value = value;

        public static Result<Description> Create(string description) =>
            string.IsNullOrWhiteSpace(description)
                ? Result.Failure<Description>("Description can't be null or empty.")
                : Result.Success(new Description(description));
    }
}
