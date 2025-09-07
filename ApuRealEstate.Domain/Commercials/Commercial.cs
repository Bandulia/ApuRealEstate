using System.Globalization;
using ApuRealEstate.Estate;

namespace ApuRealEstate.Commercials
{
    /// <summary>
    /// Base class for all commercial estates. Each subtype supplies its own m²-rate.
    /// </summary>
    public abstract class Commercial : Estate.Estate
    {
        /// <summary>
        /// Each commercial subtype must provide its monthly price per m².
        /// </summary>
        protected abstract decimal CostPerSquareMeterPerMonth { get; }

        protected Commercial() : base() { }

        protected Commercial(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        /// <summary>
        /// Numeric monthly cost (shared formula): m² * rate.
        /// </summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        /// <summary>
        /// Formatted monthly cost using the numeric value.
        /// </summary>
        public override string AccommodationCost()
            => FormatMonthlyCost(AccommodationCostPerMonth);

        protected static string FormatMonthlyCost(decimal amount, CultureInfo? culture = null)
            => string.Create(culture ?? CultureInfo.CurrentCulture, $"{amount:C}/month");
    }
}
