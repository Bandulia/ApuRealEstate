using ApuRealEstate.Estate;

namespace ApuRealEstate.Residentials
{
    /// <summary>
    /// Represents a rowhouse (terraced house). Inherits Villa behavior but applies a lower rate
    /// and an additional small HOA/community fee per month.
    /// </summary>
    internal sealed class Rowhouse : Villa
    {
        private const decimal RowhouseRatePerSquareMeter = 100m; // a bit lower than Villa
        private const decimal HoaMonthlyFee = 750m;

        // Override the rate that Villa provides
        protected override decimal CostPerSquareMeterPerMonth => RowhouseRatePerSquareMeter;

        public Rowhouse() : base() { }

        public Rowhouse(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        // Add the HOA fee on top of the base calculation
        public override decimal AccommodationCostPerMonth
            => base.AccommodationCostPerMonth + HoaMonthlyFee;

        public override string ToString()
            => $"Rowhouse · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var seller = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {seller}\n" +
                   $"Rowhouse at {Address.Street}, {Address.City}.\n" +
                   $"Area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost (incl. HOA): {AccommodationCost()}";
        }
    }
}
