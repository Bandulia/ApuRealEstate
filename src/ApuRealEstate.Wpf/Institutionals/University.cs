using ApuRealEstate.Estate;

namespace ApuRealEstate.Institutionals
{
    /// <summary>
    /// Represents a university-type institutional estate.
    /// </summary>
    internal sealed class University : Institutional
    {
        private const decimal UniversityRatePerSquareMeter = 60m;

        /// <summary>Universities usually have moderate costs per m².</summary>
        protected override decimal CostPerSquareMeterPerMonth => UniversityRatePerSquareMeter;

        /// <summary>Numeric monthly cost (explicit override for clarity).</summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        public University() : base() { }

        public University(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"University · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var sellerText = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {sellerText}\n" +
                   $"University located at {Address.Street}, {Address.City}.\n" +
                   $"Total area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
