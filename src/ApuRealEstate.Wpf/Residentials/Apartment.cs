using ApuRealEstate.Estate;

namespace ApuRealEstate.Residentials
{
    /// <summary>Represents an apartment-type residential estate.</summary>
    internal sealed class Apartment : Residential
    {
        private const decimal ApartmentRatePerSquareMeter = 85m;

        protected override decimal CostPerSquareMeterPerMonth => ApartmentRatePerSquareMeter;

        public Apartment() : base() { }

        public Apartment(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        public override string ToString()
            => $"Apartment · {Address.City}, {Address.Country} · {NumOfRooms} rooms · {SquareMeters} m²";

        public override string GetDescription()
        {
            var seller = Seller is null ? "N/A" : $"{Seller.LastName}, {Seller.FirstName}";
            return $"Seller: {seller}\n" +
                   $"Apartment at {Address.Street}, {Address.City}.\n" +
                   $"Area: {SquareMeters} m², Rooms: {NumOfRooms}\n" +
                   $"Monthly cost: {AccommodationCost()}";
        }
    }
}
