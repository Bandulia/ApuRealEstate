namespace ApuRealEstate.Persons
{
    internal sealed class Buyer : Person
    {
        private readonly HashSet<Estate.Estate> _interests;

        /// <summary>
        /// Initializes a new Buyer with a empty list of interest.
        /// </summary>
        public Buyer(string firstName, string lastName, Address address)
            : base(firstName, lastName, address)
        {
            _interests = new HashSet<Estate.Estate>(new EstateIdEqualityComparer());
        }

        /// <summary>
        /// Read only view of all interests. Does not expose the mutable collection.
        /// </summary>
        public IReadOnlyCollection<Estate.Estate> EstatesOfInterest => _interests.ToList().AsReadOnly();

        /// <summary>
        /// Adds an interest. Returns true if added, false if it already existed.
        /// </summary>
        public bool AddInterest(Estate.Estate estate)
        {
            return _interests.Add(estate);
        }

        /// <summary>
        /// Removes an interest. Returns true if something was removed.
        /// </summary>
        public bool RemoveInterest(Estate.Estate estate)
        {
            return _interests.Remove(estate);
        }

        /// <summary>
        /// Returns true if the buyer is already interested in the specified estate.
        /// </summary>
        public bool HasInterest(Estate.Estate estate)
        {
            return _interests.Contains(estate);
        }
    }
}
