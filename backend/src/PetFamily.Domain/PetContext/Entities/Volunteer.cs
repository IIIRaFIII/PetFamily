using CSharpFunctionalExtensions;
using PetFamily.Domain.PetContext.ValueObjects.VolunteerVO;
using PetFamily.Domain.PetContext.ValueObjects.PetVO;
using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.PetContext.Entities
{
    public class Volunteer : Entity
    {
        public VolunteerId Id { get; private set; }

        public FullName FullName { get; private set; }

        public Email Email { get; private set; }

        //Общее описание
        public Description Description { get; private set; }
        //Опыт
        public Experience Experience { get; private set; }
        //Количество домашних животных, которые смогли найти дом
        public int PetsWithHomeCount { get; private set; }
        //Количество домашних животных, которые ищут дом в данный момент времени
        public int PetsTryFindHomeCount { get; private set; }
        //Количество животных, которые сейчас находятся на лечении
        public int PetsUnderTreatmentCount { get; private set; }
        //Номер телефона
        public Phone PhoneNumber { get; private set; }
        //Социальные сети
        public SocialNetwork SocialNetwork { get; private set; }
        //Реквизиты для помощи
        public TransferDetails TransferDetails { get; private set; }
        //Список домашних животных, которыми владеет волонтёр.
        private readonly List<Pet> _allOwnedPets;
        public IReadOnlyList<Pet> AllOwnedPets => _allOwnedPets;


        private Volunteer(
            VolunteerId id,
            FullName fullName,
            Email email,
            Description description,
            Experience experience,
            Phone phoneNumber,
            SocialNetwork socialNetwork,
            TransferDetails transferDetails
        )
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Description = description;
            Experience = experience;
            PetsWithHomeCount = CountPetsWithHome();
            PetsTryFindHomeCount = CountPetsTryFindHome();
            PetsUnderTreatmentCount = CountPetsUnderTreatment();
            PhoneNumber = phoneNumber;
            SocialNetwork = socialNetwork;
            TransferDetails = transferDetails;
        }

        private int CountPetsWithHome() => AllOwnedPets.Count(p => p.HelpStatus.Value == PetStatus.FoundHome);
        private int CountPetsTryFindHome() => AllOwnedPets.Count(p => p.HelpStatus.Value == PetStatus.LookingHome);
        private int CountPetsUnderTreatment() => AllOwnedPets.Count(p => p.HelpStatus.Value == PetStatus.NeedHelp);

        public static Result<Volunteer> Create(
            VolunteerId id,
            FullName fullName,
            Email email,
            Description description,
            Experience experience,
            Phone phoneNumber,
            SocialNetwork socialNetwork,
            TransferDetails transferDetails)
        {
            var volunteer = new Volunteer(id, fullName, email, description, experience,
                                          phoneNumber, socialNetwork, transferDetails);

            return Result.Success(volunteer);
        }
    }
}