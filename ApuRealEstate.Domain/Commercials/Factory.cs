using ApuRealEstate.Estate;

namespace ApuRealEstate.Commercials
{
    public sealed class Factory : Commercial
    {
        protected override decimal CostPerSquareMeterPerMonth => 65m;

        private const decimal FixedMonthlyOpsFee = 5000m;

        public Factory() : base() { }

        public Factory(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override decimal AccommodationCostPerMonth
            => base.AccommodationCostPerMonth + FixedMonthlyOpsFee;

        public override string AccommodationCost()
            => FormatMonthlyCost(AccommodationCostPerMonth);

        public override string ToString()
            => $"Factory · {Address.City}, {Address.Country} · {SquareMeters} m² · {NumOfRooms} rooms";

        public override string GetDescription()
        {
            var sellerText = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {sellerText}\n" +
                   $"Factory with {NumOfRooms} rooms, total area {SquareMeters} m².\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
