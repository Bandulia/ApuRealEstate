using ApuRealEstate.Estate;

namespace ApuRealEstate.Commercials
{
    /// <summary>Represents a warehouse-type commercial estate.</summary>
    public sealed class Warehouse : Commercial
    {
        private const decimal WarehouseRatePerSquareMeter = 40m;
        private const decimal FixedMonthlyOpsFee = 2000m;

        /// <summary>Warehouse-specific monthly price per m².</summary>
        protected override decimal CostPerSquareMeterPerMonth => WarehouseRatePerSquareMeter;

        /// <summary>Numeric monthly cost including a fixed monthly ops fee.</summary>
        public override decimal AccommodationCostPerMonth
            => (SquareMeters * CostPerSquareMeterPerMonth) + FixedMonthlyOpsFee;

        public Warehouse() : base() { }

        public Warehouse(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Warehouse · {Address.City}, {Address.Country} · {SquareMeters} m² · {NumOfRooms} rooms";

        public override string GetDescription()
        {
            var sellerText = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {sellerText}\n" +
                   $"Warehouse with {NumOfRooms} rooms, total area {SquareMeters} m².\n" +
                   $"Monthly cost (incl. fixed fee): {AccommodationCost()}";
        }
    }
}
