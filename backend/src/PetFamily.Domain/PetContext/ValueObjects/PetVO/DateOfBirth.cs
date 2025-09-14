using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record DateOfBirth
    {
        public DateTime Value { get; }

        private DateOfBirth(DateTime value) => Value = value;

        public static Result<DateOfBirth> Create(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            DateTime minDate = now.AddYears(-50);

            return dateOfBirth > now
                ? Result.Failure<DateOfBirth>("Date of birth can't be in future.")
                : dateOfBirth < minDate
                    ? Result.Failure<DateOfBirth>($"Date of birth can't be older than {minDate:yyyy-MM-dd}.")
                    : Result.Success(new DateOfBirth(dateOfBirth));
        }
    }
}
