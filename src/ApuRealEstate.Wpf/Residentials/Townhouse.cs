using ApuRealEstate.Estate;

namespace ApuRealEstate.Residentials
{
    /// <summary>Represents a townhouse-type residential estate.</summary>
    internal sealed class Townhouse : Residential
    {
        private const decimal TownhouseRatePerSquareMeter = 95m;

        protected override decimal CostPerSquareMeterPerMonth => TownhouseRatePerSquareMeter;

        public Townhouse() : base() { }

        public Townhouse(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Townhouse · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var seller = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {seller}\n" +
                   $"Townhouse at {Address.Street}, {Address.City}.\n" +
                   $"Area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
