namespace ApuRealEstate.Payment
{
    public enum Option
    {
        PayPal, 
        Bank, 
        WesternUnion
    }

    internal abstract class Payment
    {
        decimal _amount;
        Option _option;

        public decimal Amount 
        {
            get => _amount;
            set => _amount = value;
        }
        
        public Option Option
        {
            get => _option;
            set => _option = value;
        }

        public Payment()
        {
            Amount = 0;
            Option = Option.PayPal;
        }

        public Payment(decimal amount, Option option) 
        {
            Amount = amount;
            Option = option;
        }
    }
}
