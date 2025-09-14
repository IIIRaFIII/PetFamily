using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.VolunteerVO
{
    public record Experience
    {
        public int Value { get; }

        private Experience(int value) => Value = value;

        public static Result<Experience> Create(int experience) =>
            experience < 0
                ? Result.Failure<Experience>("Experience can't be < 0")
                : Result.Success(new Experience(experience));
    }
}
