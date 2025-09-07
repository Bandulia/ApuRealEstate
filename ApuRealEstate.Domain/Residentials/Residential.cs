using System.Globalization;
using ApuRealEstate.Estate;

namespace ApuRealEstate.Residentials
{
    /// <summary>
    /// Base class for all residential estates (e.g. houses, apartments, villas).
    /// Provides shared logic and requires subtypes to specify their own m² rate.
    /// </summary>
    public abstract class Residential : Estate.Estate
    {
        /// <summary>
        /// Each subtype must specify its own monthly price per m².
        /// </summary>
        protected abstract decimal CostPerSquareMeterPerMonth { get; }

        protected Residential() : base() { }

        protected Residential(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller)
        { }

        /// <summary>
        /// Numeric monthly cost (m² * rate).
        /// </summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        /// <summary>
        /// Formatted monthly cost string (culture-aware).
        /// </summary>
        public override string AccommodationCost()
            => FormatMonthlyCost(AccommodationCostPerMonth);

        /// <summary>
        /// Helper for consistent currency formatting.
        /// </summary>
        protected static string FormatMonthlyCost(decimal amount, CultureInfo? culture = null)
            => string.Create(culture ?? CultureInfo.CurrentCulture, $"{amount:C}/month");
    }
}
