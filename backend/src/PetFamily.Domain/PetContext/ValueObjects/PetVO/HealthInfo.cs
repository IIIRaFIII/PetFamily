using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record HealthInfo
    {
        public string Value { get; }

        private HealthInfo(string value) => Value = value;

       public static Result<HealthInfo> Create(string healthInfo) =>
            string.IsNullOrWhiteSpace(healthInfo)
                ? Result.Failure<HealthInfo>("HealthInfo can't be null or empty")
                : Result.Success(new HealthInfo(healthInfo));
    }
}
