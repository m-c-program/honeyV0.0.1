using Newtonsoft.Json;
using QuickType;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace honeyV0._0._1
{
     static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            /* Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1());*/

            Website wb = new Website("https://www.deadstock.ca");

            CreditCard cc = new CreditCard(4444444444444444, "willem seamon", 12, 2020, 999);

            CheckoutInfo ci = new CheckoutInfo("wfseamo@gmail.com", "willem", "seamon", "56 Radcliff Ln", "Pueblo", "Colorado", "USA", 81005, "7194230444");

            Profile p = new Profile(cc, ci);

            List<string> keywords = new List<string>
            {
                "Dad",
                "Hat"
            };


            //before tasks
            var token = cc.GetPaymentToken();
            Console.WriteLine(token + " is the payment token");
            var products = wb.GetProducts();

            //tasks
            var prod = wb.FindProduct(products, keywords);
            Console.WriteLine(prod.Title + " found with keywords: " + keywords.ToString());
            
        }

        
      
        }
    }

