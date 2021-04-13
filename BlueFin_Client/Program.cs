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
            GetProductDetail(1, "Equipment").Wait();
            GetProductDetail(1, "Livestock").Wait();
        }

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
    }
}
