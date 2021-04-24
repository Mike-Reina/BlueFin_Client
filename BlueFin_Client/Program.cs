using Blue_Fin_Inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlueFin_Client
{
    class Program
    {
        static void Main()
        {
            //Products
            Console.WriteLine("Please provide Equipment Id #");
            int equipInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Equipment #" + equipInput + " details are the following");
            GetProductDetail(equipInput, "Equipment").Wait(); 
            Console.WriteLine();

            Console.WriteLine("Please provide Equipment Id #");
            int liveInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Equipment #" + liveInput + " details are the following");
            GetProductDetail(liveInput, "Livestock").Wait();
            Console.WriteLine();

            //Order
            Console.WriteLine("Please provide Order Number #");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Order #" + userInput + " details are the following");
            Console.WriteLine();
            GetOrderDetails(userInput).Wait();
            Console.WriteLine();
        }

        //Async Methods
        public static async Task GetProductDetail(int ProductCode, string ProductType)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://bluefininc.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (ProductType == "Equipment")
            {
                HttpResponseMessage response = await client.GetAsync("Equipment/Details/" + ProductCode + "?json=yes");

                if (response.IsSuccessStatusCode)
                {
                    Equipment equipFound = await response.Content.ReadAsAsync<Equipment>();
                    Console.WriteLine(equipFound.ToString());
                }
                else
                {
                    Console.WriteLine(response.StatusCode + "\nReasonPhrase: " + response.ReasonPhrase + "\n");
                }
            }
            else
            {
                HttpResponseMessage response = await client.GetAsync("Livestock/Details/" + ProductCode + "?json=yes");

                if (response.IsSuccessStatusCode)
                {
                    Livestock liveFound = await response.Content.ReadAsAsync<Livestock>();
                    Console.WriteLine(liveFound.ToString());
                }
                else
                {
                    Console.WriteLine(response.StatusCode + "\nReasonPhrase: " + response.ReasonPhrase + "\n");
                }
            }
        }

   
        private static async Task GetOrderDetails(int id)
        {
            try
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://bluefininc.azurewebsites.net/");

                //3. Adding a accept header eg. application/json
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //4. HTTP response from the GET API -- async call, await suspends until task finished
                HttpResponseMessage response = await client.GetAsync("/Order/ShowOrderDetails/" + id + "?json=yes");

                if (response.IsSuccessStatusCode)
                {
                    Order orderRecord = await response.Content.ReadAsAsync<Order>();
                 
                    Console.WriteLine(orderRecord.ToString());
                }
                else
                {
                    Console.WriteLine("Status Code: " + response.StatusCode + ", Reason Phrase: " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }




    }
}
