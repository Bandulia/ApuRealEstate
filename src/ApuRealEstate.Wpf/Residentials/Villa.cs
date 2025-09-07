using ApuRealEstate.Estate;

namespace ApuRealEstate.Residentials
{
    /// <summary>Represents a villa-type residential estate.</summary>
    internal class Villa : Residential
    {
        private const decimal VillaRatePerSquareMeter = 110m;

        protected override decimal CostPerSquareMeterPerMonth => VillaRatePerSquareMeter;

        public Villa() : base() { }

        public Villa(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Villa · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var seller = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {seller}\n" +
                   $"Villa at {Address.Street}, {Address.City}.\n" +
                   $"Area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
