using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.VolunteerVO
{
    public record SocialNetwork
    {
        public string Link { get; }
        public string Name { get; }

        private SocialNetwork(string link, string name) =>
            (Link, Name) = (link, name);

        public static Result<SocialNetwork> Create(string link, string name) =>
            string.IsNullOrWhiteSpace(link) ? Result.Failure<SocialNetwork>("Link can't be null or empty.") :
            string.IsNullOrWhiteSpace(name) ? Result.Failure<SocialNetwork>("Link's name can't be null or empty.") :
            Result.Success(new SocialNetwork(link, name));
    }

}
