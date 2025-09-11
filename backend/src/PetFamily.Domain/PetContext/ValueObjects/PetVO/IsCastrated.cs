using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record IsCastrated
    {
        public bool Value { get; }

        private IsCastrated(bool value) => Value = value;

        public static Result<IsCastrated> Create(bool isCastrated) =>
            Result.Success(new IsCastrated(isCastrated));
    }
}
