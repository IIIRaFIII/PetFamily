using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record TransferDetailsList
    {
        private readonly List<TransferDetails> _donationDetails;
        public IReadOnlyList<TransferDetails> DonationDetails => _donationDetails;

        private TransferDetailsList(IEnumerable<TransferDetails> donationDetails) =>
            _donationDetails = donationDetails.ToList();

        public static Result<TransferDetailsList> Create(IEnumerable<TransferDetails> donationDetails) =>
            donationDetails == null || !donationDetails.Any()
                ? Result.Failure<TransferDetailsList>("Donation details list can't be null or empty.")
                : Result.Success(new TransferDetailsList(donationDetails));
    }
}
