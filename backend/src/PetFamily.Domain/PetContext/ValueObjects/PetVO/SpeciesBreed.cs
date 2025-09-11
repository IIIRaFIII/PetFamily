using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record SpeciesBreed
    {
        public Guid SpeciesId { get; }
        public Guid BreedId { get; }

        private SpeciesBreed(Guid speciesId, Guid breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }

        public static Result<SpeciesBreed> Create(Guid breedId, Guid speciesId)
        {
            if (breedId == Guid.Empty)
                return Result.Failure<SpeciesBreed>("breedId cannot be empty.");
            if (speciesId == Guid.Empty)
                return Result.Failure<SpeciesBreed>("speciesId cannot be empty.");

            var validPetClassification = new SpeciesBreed(breedId, speciesId);
            return Result.Success(validPetClassification);
        }
    }
}
