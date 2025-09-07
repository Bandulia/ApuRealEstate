namespace ApuRealEstate.Payment
{
    internal class PayPal : Payment
    {
        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public PayPal(string email, decimal amount, Option option) : base(amount, option) 
        {
            Email = email;
        }
    }
}
