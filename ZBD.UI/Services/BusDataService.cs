using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ZBD.UI.Models;

namespace ZBD.UI.Services
{
    public static class BusDataService
    {

        public static BusData GetBusDataByName(string name)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:31151/api/buses/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync(name).Result;

          //  if (response.IsSuccessStatusCode)
            //{
                var dataObjects = response.Content.ReadAsStringAsync().Result;
           // }

            BusData busData = JsonConvert.DeserializeObject<BusData>(dataObjects);
            //  //  var busData = new BusData()
            //{
            //    Id = Guid.NewGuid(),
            //    Length = 15,
            //    Model = "0001",
            //    Name = "Autobus test 1",
            //    Seats = 56,
            //    Width = 3
            //};

            return busData;
        }

        public static void GenerateAndInsertRandomData()
        {
            var random = new Random();
            for (int i = 0; i < 50; i++)
            {
                var busToCreate = new BusData()
                {
                    Length = random.Next(20, 50),
                    Width = random.Next(10, 30),
                    Model = Path.GetRandomFileName(),
                    Name = "Autobus nr " + i.ToString(),
                    Seats = random.Next(40, 50),
                    Passengers = new List<Passenger>()
                };
                for (int j = 0; j < random.Next(3,7); j++)
                {
                    busToCreate.Passengers.Add(
                        new Passenger()
                        {
                            Age = random.Next(10, 99),
                            Name = Path.GetRandomFileName(),
                            Surname = Path.GetRandomFileName(),
                            Ticket = random.Next(0, 1) == 1 ? true : false
                        });
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:31151/api/buses/");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(busToCreate);
    
                streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }

            
        }
    }
}
