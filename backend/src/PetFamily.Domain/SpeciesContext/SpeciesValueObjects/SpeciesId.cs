using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.SpeciesContext.ValueObjects
{
    public record SpeciesId
    {
        public Guid Value {  get; }

        private SpeciesId(Guid value)
        {
            Value = value;
        }

        public static Result<SpeciesId> Create(Guid value) =>
            value == Guid.Empty
                ? Result.Failure<SpeciesId>("SpeciesId cannot be empty.")
                : Result.Success(new SpeciesId(value));

        public static SpeciesId NewBreedId() => new(Guid.NewGuid());

        public static SpeciesId EmptyBreedId() => new(Guid.Empty);
    }
}
