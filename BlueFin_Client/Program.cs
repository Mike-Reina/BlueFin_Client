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
            GetProductDetail(1, "Equipment").Wait();
            GetProductDetail(1, "Livestock").Wait();

            //Order
            Console.WriteLine("Please provide Order Number #");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Order #" + userInput + " details are the following");
            Console.WriteLine();
            GetCustOrderByID(userInput).Wait();
            Console.WriteLine();
        }

        //Async Methods
        public static async Task GetProductDetail(int ProductCode, string ProductType)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:32679");
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

   
        private static async Task GetCustOrderByID(int id)
        {
            try
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://localhost:32679/");

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
