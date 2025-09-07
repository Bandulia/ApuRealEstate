namespace ApuRealEstate.Payment
{
    internal class WesternUnion : Payment
    {
        private string name = string.Empty;
        private string email = string.Empty;

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }
        public string Email 
        { 
            get => email; 
            set => email = value; 
        }

        public WesternUnion(string name, string email, decimal amount, Option option) : base(amount, option)
        {
            Name = name;
            Email = email;
        }
    }
}
