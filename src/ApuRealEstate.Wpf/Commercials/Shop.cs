using ApuRealEstate.Estate;

namespace ApuRealEstate.Commercials
{
    /// <summary>Represents a shop-type commercial estate.</summary>
    internal sealed class Shop : Commercial
    {
        private const decimal ShopRatePerSquareMeter = 80m;

        /// <summary>Shop-specific monthly price per m².</summary>
        protected override decimal CostPerSquareMeterPerMonth => ShopRatePerSquareMeter;

        /// <summary>Numeric monthly cost (explicit override for clarity).</summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        public Shop() : base() { }

        public Shop(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Shop · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var sellerText = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {sellerText}\n" +
                   $"Shop at {Address.Street}, {Address.City}.\n" +
                   $"Area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
