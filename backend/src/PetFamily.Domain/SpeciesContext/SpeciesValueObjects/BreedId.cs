using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.SpeciesContext.ValueObjects
{
    public record BreedId
    {
        public Guid Value { get; }

        private BreedId(Guid value)
        {
            Value = value;
        }

        public static Result<BreedId> Create(Guid value) =>
            value == Guid.Empty
                ? Result.Failure<BreedId>("BreedId cannot be empty.")
                : Result.Success(new BreedId(value));

        public static BreedId NewBreedId() => new(Guid.NewGuid());

        public static BreedId EmptyBreedId() => new(Guid.Empty);
    }
}
