using CSharpFunctionalExtensions;
using PetFamily.Domain.PetContext.ValueObjects.PetVO;
using PetFamily.Domain.PetContext.ValueObjects.VolunteerVO;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.PetContext.Entities
{
    public class Pet : Entity 
    { 
        public PetId Id { get; private set; }
        // Кличка
        public Name Name { get; private set; }
        // Вид и порода (VO)
        public SpeciesBreed SpeciesBreed { get; private set; }
        // Общее описание
        public Description Description { get; private set; }
        // Окрас
        public Color Color { get; private set; }
        // Состояние здоровья
        public HealthInfo HealthInfo { get; private set; }
        // Адрес питомца (VO)
        public Address Address { get; private set; }
        // Вес и рост (VO)
        public Weight Weight { get; private set; }
        public Height Height { get; private set; }
        // Номер телефона владельца (VO)
        public Phone OwnerPhoneNumber { get; private set; }
        // Кастрирован или нет
        public IsCastrated IsCastrated { get; private set; }
        // Вакцинирован или нет
        public IsVaccinated IsVaccinated { get; private set; }
        // Дата рождения
        public DateOfBirth DateOfBirth { get; private set; }
        // Статус помощи
        public HelpStatus HelpStatus { get; private set; }
        // Реквизиты для помощи (VO)
        public TransferDetails TransferDetails { get; private set; }
        // Дата создания
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        protected Pet() { }
        public Pet(
        PetId id,
        Name name,
        Description description,
        SpeciesBreed speciesBreed,
        Color color,
        HealthInfo healthInfo,
        Address address,
        Weight weight,
        Height height,
        Phone ownerPhoneNumber,
        IsCastrated isCastrated,
        DateOfBirth dateOfBirth,
        IsVaccinated isVaccinated,
        HelpStatus helpStatus,
        TransferDetails transferDetails
        )
        {
        Id = id;
        Name = name;
        SpeciesBreed = speciesBreed;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Height = height;
        Weight = weight;
        OwnerPhoneNumber = ownerPhoneNumber;
        IsCastrated = isCastrated;
        DateOfBirth = dateOfBirth;
        IsVaccinated = isVaccinated;
        HelpStatus = helpStatus;
        TransferDetails = transferDetails;
        }

        public static Result<Pet> Create(
            PetId id,
            Name name,
            Description description,
            SpeciesBreed speciesBreed,
            Color color,
            HealthInfo healthInfo,
            Address address,
            Weight weight,
            Height height,
            Phone ownerPhoneNumber,
            IsCastrated isCastrated,
            DateOfBirth dateOfBirth,
            IsVaccinated isVaccinated,
            HelpStatus helpStatus,
            TransferDetails transferDetails)
        {
            var pet = new Pet(
                id,
                name,
                description,
                speciesBreed,
                color,
                healthInfo,
                address,
                weight,
                height,
                ownerPhoneNumber,
                isCastrated,
                dateOfBirth,
                isVaccinated,
                helpStatus,
                transferDetails
            );

            return Result.Success(pet);
        }
    }
}
