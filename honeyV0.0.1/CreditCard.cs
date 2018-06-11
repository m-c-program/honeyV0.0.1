using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honeyV0._0._1
{
    class CreditCard
    {
        private long CardNumber { get; set; }
        private String Name { get; set; }
        private int ExpMonth { get; set; }
        private int ExpYear { get; set; }
        private int Cvv { get; set; }

        public CreditCard(long cc, String name, int expm, int expy, int cvv) {
            CardNumber = cc;
            Name = name;
            ExpMonth = expm;
            ExpYear = expy;
            Cvv = cvv;
        }

        public string GetPaymentToken() {
            var client = new RestClient("https://elb.deposit.shopifycs.com/sessions");
            var request = new RestRequest(Method.POST);

            request.AddParameter("number", CardNumber);
            request.AddParameter("name", Name);
            request.AddParameter("month", ExpMonth);
            request.AddParameter("year", ExpYear);
            request.AddParameter("verification_value", Cvv);

            IRestResponse<PaymentToken> response2 = client.Execute<PaymentToken>(request);
            var token = response2.Data.id;

            return token;
        }

    }
}
