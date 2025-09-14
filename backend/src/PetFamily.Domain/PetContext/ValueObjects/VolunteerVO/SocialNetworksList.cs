using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.VolunteerVO
{
    public class SocialNetworksList
    {
        private readonly List<SocialNetwork> _socialNetworks;
        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

        private SocialNetworksList(IEnumerable<SocialNetwork> socialNetworks)
        {
            _socialNetworks = socialNetworks.ToList();
        }

        public static Result<SocialNetworksList> Create(IEnumerable<SocialNetwork> socialNetworks) =>
            Result.Success(new SocialNetworksList(socialNetworks));
    }
}
