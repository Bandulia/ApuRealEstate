using ApuRealEstate.Estate;

namespace ApuRealEstate.Institutionals
{
    /// <summary>
    /// Represents a hospital-type institutional estate.
    /// </summary>
    internal sealed class Hospital : Institutional
    {
        private const decimal HospitalRatePerSquareMeter = 90m;

        /// <summary>Hospitals typically have high running costs per m².</summary>
        protected override decimal CostPerSquareMeterPerMonth => HospitalRatePerSquareMeter;

        /// <summary>Numeric monthly cost (explicit override for clarity).</summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        public Hospital() : base() { }

        public Hospital(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Hospital · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var sellerText = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {sellerText}\n" +
                   $"Hospital located at {Address.Street}, {Address.City}.\n" +
                   $"Total area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
