using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record Color
    {
        public string Value { get; }

        private Color(string value) => Value = value;
        
        public static Result<Color> Create(string color) =>
            string.IsNullOrWhiteSpace(color)
                ? Result.Failure<Color>("Color can't be null or empty.")
                : Result.Success(new Color(color));
    }
}
