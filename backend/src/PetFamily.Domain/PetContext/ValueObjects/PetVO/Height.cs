using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record Height
    {
        public float Value { get; }

        private Height(float value) => Value = value;

        public static Result<Height> Create(float height) =>
            height <= 0
                ? Result.Failure<Height>("Height can't be < 0")
                : Result.Success(new Height(height));
    }
}
