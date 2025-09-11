using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.ValueObjects.PetVO
{
    public record HelpStatus
    {
        public PetStatus Value { get; }

        private HelpStatus(PetStatus value) => Value = value;

        public static Result<HelpStatus> Create(PetStatus helpStatus) =>
            Result.Success(new HelpStatus(helpStatus));
    }

    public enum PetStatus
    {
        NeedHelp,
        LookingHome,
        FoundHome
    }
}
