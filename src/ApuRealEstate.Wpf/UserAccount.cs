using ApuRealEstate.Persons;

namespace Assignment_1_version_1
{
    internal class UserAccount
    {
        public Seller SellerIdentity { get; }
        public Buyer BuyerIdentity { get; }

        public UserAccount(Seller seller, Buyer buyer)
        {
            SellerIdentity = seller ?? throw new ArgumentNullException(nameof(seller));
            BuyerIdentity = buyer ?? throw new ArgumentNullException(nameof(buyer));
        }
    }
}
