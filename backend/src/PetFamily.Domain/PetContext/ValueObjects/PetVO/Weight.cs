using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record Weight
    {
        public float Value { get; }

        private Weight(float value) => Value = value;

        public static Result<Weight> Create(float weight) =>
            weight <= 0
                ? Result.Failure<Weight>("Weight can't be < 0")
                : Result.Success(new Weight(weight));
    }
}
