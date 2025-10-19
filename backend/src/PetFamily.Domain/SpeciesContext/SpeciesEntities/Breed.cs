using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.SpeciesContext.Entities
{
    public class Breed : Entity
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        private Breed(string name)
        {
            Name = name;
        }

        protected Breed() { }

        public static Result<Breed> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Breed>("Breed name cannot be null or empty");

            var breed = new Breed(name);

            return Result.Success(breed);
        }
    }
}
