namespace ApuRealEstate.Persons
{
    public sealed class Seller : Person
    {
        private readonly HashSet<Estate.Estate> _listedEstates;

        /// <summary>
        /// Initializes a new Seller with a empty list of listed estates.
        /// </summary>
        public Seller(string firstName, string lastName, Address address)
            : base(firstName, lastName, address)
        {
            _listedEstates = new HashSet<Estate.Estate>(new EstateIdEqualityComparer());
        }

        /// <summary>
        /// Read only view of all listed estates. Does not expose the mutable collection.
        /// </summary>
        public IReadOnlyCollection<Estate.Estate> ListedEstates => _listedEstates.ToList().AsReadOnly();

        /// <summary>
        /// Adds a listing. Returns true if added, false if it already existed.
        /// </summary>
        public bool AddListing(Estate.Estate estate)
        {
            return _listedEstates.Add(estate);
        }

        /// <summary>
        /// Removes a listing. Returns true if something was removed.
        /// </summary>
        public bool RemoveListing(Estate.Estate estate)
        {
            return _listedEstates.Remove(estate);
        }

        /// <summary>
        /// Returns true if the seller already listed the estate.
        /// </summary>
        public bool HasListing(Estate.Estate estate)
        {
            return _listedEstates.Contains(estate);
        }
    }
}
