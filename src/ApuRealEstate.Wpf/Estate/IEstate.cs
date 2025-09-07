namespace ApuRealEstate.Estate
{
    public enum LegalForm
    {
        Ownership,
        Tenement,
        Rental
    }

    /// <summary>
    /// Contract for an estate. Setters are included by design since the caller needs mutability.
    /// Validation is enforced by the abstract base class implementation.
    /// </summary>
    public interface IEstate
    {
        string Id { get; set; }
        Address Address { get; set; }
        int SquareMeters { get; set; }
        int NumOfRooms { get; set; }
        LegalForm LegalForm { get; set; }
        string? ImagePath { get; set; }
        Persons.Seller? Seller { get; set; }

        /// <summary>Monthly accommodation cost as a numeric value (for calculations).</summary>
        decimal AccommodationCostPerMonth { get; }

        /// <summary>Formatted accommodation cost (for UI/logs).</summary>
        string AccommodationCost();

        /// <summary>Readable description of this estate.</summary>
        string GetDescription();
    }
}
