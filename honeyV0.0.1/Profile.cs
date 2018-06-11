namespace honeyV0._0._1
{
    class Profile
    {
       CreditCard cc { get; set; }
       CheckoutInfo ci { get; set; }

        public Profile(CreditCard cc1, CheckoutInfo ci1) {
            cc = cc1;
            ci = ci1;
        }
    }
}