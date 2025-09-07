namespace ApuRealEstate
{
    public enum Country
    {
        UnitedStates,
        Canada,
        Germany,
        Japan,
        Brazil,
        Australia,
        India,
        SouthAfrica,
        UnitedKingdom,
        France
    }

    public enum City
    {
        NewYork,        // United States
        Toronto,        // Canada
        Berlin,         // Germany
        Tokyo,          // Japan
        SãoPaulo,       // Brazil
        Sydney,         // Australia
        Mumbai,         // India
        CapeTown,       // South Africa
        London,         // United Kingdom
        Paris           // France
    }


    public class Address
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }

        public Address()
        {       
            Country = Country.UnitedStates;
            City= City.NewYork;
            ZipCode = "215-85";
            Street = "Unknown";
        }
        public Address(Country country, City city, string zip, string street)
        {
            Country = country;
            City = city;
            ZipCode = zip;
            Street = street;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the address.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Street}, {ZipCode} {City}, {Country}";
    }
}
