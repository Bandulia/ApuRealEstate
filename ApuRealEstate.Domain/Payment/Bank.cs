namespace ApuRealEstate.Payment
{
    internal class Bank : Payment
    {
        private string _name = string.Empty;
        private string _accountnumber = string.Empty; 

        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }

        public string Accountnumber 
        { 
            get => _accountnumber; 
            set => _accountnumber = value; 
        }

        public Bank(string name, string accountNbr, decimal amount, Option option) : base(amount, option) 
        {
            Name = name;
            Accountnumber = accountNbr;
        }
    }
}
