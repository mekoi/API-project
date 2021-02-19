using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAPIClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {           
            RunAysnc().GetAwaiter().GetResult();
        }

        static async Task RunAysnc()
        {
            client.BaseAddress = new Uri("http://imeko-eval-prod.apigee.net/project-proxy/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", "GpyAoSX1YOaybYTPz0yAqaRcqkFhpg7C");

            try
            {
                string json;
                HttpResponseMessage response;
                ////GET ALL
                //response = await client.GetAsync("api/allPricesOfInstruments.json");
                //if (response.IsSuccessStatusCode)
                //{
                //    json = await response.Content.ReadAsStringAsync();

                //    IEnumerable<MarketPrice> prices = JsonConvert.DeserializeObject<IEnumerable<MarketPrice>>(json);
                //    Console.WriteLine("GET All");
                //    Console.WriteLine("---------------------------------------------------------------------");
                //    foreach (MarketPrice item in prices)
                //    {
                //        Console.WriteLine(item.ToString());
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Internal Server Error");
                //}

                ////GET BY ID
                //int instrumentId = 11;
                //response = await client.GetAsync("api/Price/" + instrumentId);
                //if (response.IsSuccessStatusCode)
                //{
                //    json = await response.Content.ReadAsStringAsync();

                //    IEnumerable<MarketPrice> pricesByInstrumentId = JsonConvert.DeserializeObject<IEnumerable<MarketPrice>>(json);
                //    Console.WriteLine("Get prices by Instrument Id = 11");
                //    Console.WriteLine("---------------------------------------------------------------------");
                //    foreach (MarketPrice item in pricesByInstrumentId)
                //    {
                //        Console.WriteLine(item.ToString());
                //    }                  
                //}
                //else
                //{
                //    Console.WriteLine("Internal Server Error");
                //}

                ////POST
                //MarketPrice newPrice = new MarketPrice();
                //newPrice.InstrumentId = 11;
                //newPrice.Date = DateTime.Parse("2020-12-02T00:00:00");
                //newPrice.Price = 99.99;

                //json = JsonConvert.SerializeObject(newPrice);
                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //response = await client.PostAsync("api/Price", content);
                //Console.WriteLine("");
                //Console.WriteLine($"status from POST {response.StatusCode}");
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine($"added resource at {response.Headers.Location}");
                //json = await response.Content.ReadAsStringAsync();
                //Console.WriteLine("---------------The File has been inserted------------------");
                //Console.WriteLine(json);

                //PUT
                MarketPrice price2Update = new MarketPrice()
                {
                    PriceId = 108,
                    InstrumentId = 11,
                    Date = DateTime.Parse("2030-12-02T00:00:00"),
                    Price = 66.66
                };



                json = JsonConvert.SerializeObject(price2Update);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PutAsync("api/Price/108", content);
                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();

                ////DELETE
                //int priceId2Delete = 107;
                //response = await client.DeleteAsync("api/Price/" + priceId2Delete);
                //Console.WriteLine($"status from Delete {response.StatusCode}");
                //response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

            }
        }
    }
}
