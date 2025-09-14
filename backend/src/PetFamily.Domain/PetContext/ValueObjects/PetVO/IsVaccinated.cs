using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record IsVaccinated
    {
        public bool Value { get; }

        private IsVaccinated(bool value) => Value = value;

        public static Result<IsVaccinated> Create(bool isVaccinated) =>
            Result.Success(new IsVaccinated(isVaccinated));
    }
}
