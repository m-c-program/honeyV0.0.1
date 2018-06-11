using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honeyV0._0._1
{

    class CheckoutInfo 
    {
        private string Email { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Addy { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string Country { get; set; }
        private int ZipCode { get; set; }
        private string PhoneNumber { get; set; }

        public CheckoutInfo(string e, string fn, string ln, string ad, string ct, string st, string co, int zip, string pn) {
            Email = e;
            FirstName = fn;
            LastName = ln;
            Addy = ad;
            City = ct;
            State = st;
            Country = co;
            ZipCode = zip;
            PhoneNumber = pn;
        }

    }
}
/*
email = "email@domain.com"
fname = "Bill"
lname = "Nye"
addy1 = "123 Jolly St"
addy2 = ""  # Can be left blank
city = "Toronto"
province = "Ontario"
country = "Canada"
postal_code = "M1G1E4"
phone = "4169671111"
*/
