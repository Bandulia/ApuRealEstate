using System.Globalization;

namespace ApuRealEstate.Estate
{
    /// <summary>
    /// Base class providing validation, default formatting, and shared behavior for all estates.
    /// Concrete subtypes must decide how to compute <see cref="AccommodationCostPerMonth"/>.
    /// </summary>
    public abstract class Estate : IEstate
    {
        // backing fields for validation
        private string _id = string.Empty;
        private Address _address = new Address();
        private int _squareMeters;
        private int _numOfRooms;

        /// <summary>Domain-unique identifier for the estate.</summary>
        public string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Id cannot be null or empty.", nameof(Id));
                _id = value;
            }
        }

        /// <summary>Street address and locality information.</summary>
        public Address Address
        {
            get => _address;
            set => _address = value ?? throw new ArgumentNullException(nameof(Address));
        }

        /// <summary>Total area in square meters. Must be &gt;= 0.</summary>
        public int SquareMeters
        {
            get => _squareMeters;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(SquareMeters), "Square meters cannot be negative.");
                _squareMeters = value;
            }
        }

        /// <summary>Number of rooms. Must be &gt;= 0.</summary>
        public int NumOfRooms
        {
            get => _numOfRooms;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(NumOfRooms), "Number of rooms cannot be negative.");
                _numOfRooms = value;
            }
        }

        /// <summary>Legal form (ownership/tenement/rental).</summary>
        public LegalForm LegalForm { get; set; }

        /// <summary>Optional image path or URI.</summary>
        public string? ImagePath { get; set; }

        /// <summary>The seller/owner entity responsible for the listing. May be null for drafts.</summary>
        public Persons.Seller? Seller { get; set; }

        /// <summary>
        /// Parameterless constructor for tooling/ORMs/UI binding. Sets safe defaults.
        /// </summary>
        protected Estate()
        {
            Id = "E000";
            Address = new Address();
            SquareMeters = 0;
            NumOfRooms = 0;
            LegalForm = LegalForm.Ownership;
            ImagePath = "No image";
            Seller = null;
        }

        /// <summary>
        /// Full constructor. Assigns via properties to reuse validation.
        /// </summary>
        public Estate(
            string id,
            Address address,
            int squareMeters,
            int numOfRooms,
            LegalForm legalForm,
            string? imagePath = null,
            Persons.Seller? seller = null)
        {
            Id = id;
            Address = address;
            SquareMeters = squareMeters;
            NumOfRooms = numOfRooms;
            LegalForm = legalForm;
            ImagePath = imagePath ?? "No image";
            Seller = seller;
        }

        /// <summary>
        /// Monthly accommodation cost as a numeric value (currency is a caller concern).
        /// Must be implemented by concrete subtypes.
        /// </summary>
        public abstract decimal AccommodationCostPerMonth { get; }

        /// <summary>
        /// Returns the accommodation cost formatted for the current UI culture.
        /// Override if you need custom formatting.
        /// </summary>
        public virtual string AccommodationCost() =>
            string.Create(CultureInfo.CurrentCulture, $"{AccommodationCostPerMonth:C}/month");

        /// <summary>
        /// Returns a human-readable description. Override to add subtype-specific info.
        /// </summary>
        public virtual string GetDescription()
            => $"Estate id: {Id}\nAddress: {Address}\nEstate size: {SquareMeters} m²\nNumber of rooms: {NumOfRooms}\nForm: {LegalForm}";

        /// <summary>
        /// Compact diagnostics string. Keep it lightweight (no heavy formatting).
        /// </summary>
        public override string ToString()
            => $"{Id} | {LegalForm} | {SquareMeters} m² | {NumOfRooms} rooms";
    }
}
