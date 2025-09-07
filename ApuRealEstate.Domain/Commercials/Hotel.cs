using ApuRealEstate.Estate;

namespace ApuRealEstate.Commercials
{
    /// <summary>Represents a hotel-type commercial estate.</summary>
    public sealed class Hotel : Commercial
    {
        private const decimal HotelRatePerSquareMeter = 120m;

        /// <summary>Hotel-specific monthly price per m².</summary>
        protected override decimal CostPerSquareMeterPerMonth => HotelRatePerSquareMeter;

        /// <summary>Numeric monthly cost (explicit override for clarity).</summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        public Hotel() : base() { }

        public Hotel(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Hotel · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var sellerText = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {sellerText}\n" +
                   $"Hotel located at {Address.Street}, {Address.City}.\n" +
                   $"Area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
