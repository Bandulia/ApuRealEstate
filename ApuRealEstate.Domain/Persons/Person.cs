namespace ApuRealEstate.Persons
{
    public abstract class Person
    {
        private string _firstName = "Unknown";
        private string _lastName = "Unknown";
        private Address _address = new Address();

        public string FirstName
        {
            get => _firstName;
            protected set => _firstName = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public string LastName
        {
            get => _lastName;
            protected set => _lastName = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public Address Address
        {
            get => _address;
            protected set => _address = value ?? new Address();
        }

        /// <summary>
        /// Initializes a new Person with safe defaults.
        /// </summary>
        protected Person(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
