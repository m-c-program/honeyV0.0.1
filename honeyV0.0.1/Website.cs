using QuickType;
using RestSharp;
using System;
using System.Collections.Generic;

namespace honeyV0._0._1
{
    class Website
    {
        public string url { get; set; }

        public Website(string ur) {
            url = ur;
        }

        public Products GetProducts()
        {
            var client = new RestClient(url + "/products.json");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            var products = Products.FromJson(content);

            Console.WriteLine("successfully retrived items");
            return products;
        }

        public Product FindProduct(Products prod, List<String> str) {
            Product p1 = new Product();
            p1.Title = "default title";
            var keys = 0;
            foreach (Product p in prod.ProductsProducts) {
                foreach (string st in str) {
                    if (p.Title.ToUpper().Contains(st.ToUpper())) {
                        keys++;
                    }
                }
               if(keys == str.Count)
                {
                    return p;
                }
            }        
            return p1;
        }


    }
}