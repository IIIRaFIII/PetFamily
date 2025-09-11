using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record TransferDetails
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private TransferDetails(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Result<TransferDetails> Create(string name, string description) =>
            string.IsNullOrWhiteSpace(name)
                ? Result.Failure<TransferDetails>("Name of TransferDetails can't be null or empty.")
                : string.IsNullOrWhiteSpace(description)
                    ? Result.Failure<TransferDetails>("Description of TransferDetails can't be null or empty.")
                    : Result.Success(new TransferDetails(name, description));
    }
}
