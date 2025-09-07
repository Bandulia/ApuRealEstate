using System.Globalization;
using ApuRealEstate.Estate;

namespace ApuRealEstate.Institutionals
{
    /// <summary>
    /// Base class for all institutional estates (e.g. schools, hospitals, universities).
    /// Locks the estate category to <see cref="Category.Institutional"/> 
    /// and provides a shared cost model (m² * rate).
    /// </summary>
    internal abstract class Institutional : Estate.Estate
    {
        /// <summary>
        /// Each subtype must specify its own monthly rate per m².
        /// </summary>
        protected abstract decimal CostPerSquareMeterPerMonth { get; }

        protected Institutional() : base() { }

        protected Institutional(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
            : base(id, address, squareMeters, numOfRooms, legalForm, imagePath, seller) { }

        /// <summary>
        /// Numeric monthly accommodation cost (m² * subtype's rate).
        /// </summary>
        public override decimal AccommodationCostPerMonth
            => SquareMeters * CostPerSquareMeterPerMonth;

        /// <summary>
        /// Formatted cost string, culture-aware.
        /// </summary>
        public override string AccommodationCost()
            => FormatMonthlyCost(AccommodationCostPerMonth);

        /// <summary>
        /// Helper for consistent cost formatting.
        /// </summary>
        protected static string FormatMonthlyCost(decimal amount, CultureInfo? culture = null)
            => string.Create(culture ?? CultureInfo.CurrentCulture, $"{amount:C}/month");
    }
}
