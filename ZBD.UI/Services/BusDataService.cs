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


                var dataObjects = response.Content.ReadAsStringAsync().Result;


            BusData busData = JsonConvert.DeserializeObject<BusData>(dataObjects);
         

            return busData;
        }

        public static void GenerateAndInsertRandomData()
        {
            List<string> localizations = new List<string>
            {
                "Warszawa","Białystok","Szczecin","Poznań","Wrocław","Gdańsk","Sosnowiec","Radom","Gdynia","Łapy","Uhowo","Grajewo"
            };

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
                    Localization = localizations[random.Next(0, 12)],
                    Passengers = new List<Passenger>()
                };
                for (int j = 0; j < random.Next(3,14); j++)
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

        public static void UpdateData()
        {
            List<string> localizations = new List<string>
            {
                "Warszawa","Białystok","Szczecin","Poznań","Wrocław","Gdańsk","Sosnowiec","Radom","Gdynia","Łapy","Uhowo","Grajewo"
            };

            var random = new Random();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:31151/api/buses/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync("").Result;

            //  if (response.IsSuccessStatusCode)
            //{
            var dataObjects = response.Content.ReadAsStringAsync().Result;
            // }

            List<BusData> busesData = JsonConvert.DeserializeObject<List<BusData>>(dataObjects);


            foreach(BusData busData in busesData)
            {
                var httpWebRequestClear = (HttpWebRequest)WebRequest.Create("http://localhost:31151/api/buses/" + busData.Id.ToString());
                httpWebRequestClear.ContentType = "application/json";
                httpWebRequestClear.Method = "DELETE";

                var httpResponseClear = (HttpWebResponse)httpWebRequestClear.GetResponse();



                var busToCreate = new BusData()
                {
                    Id = busData.Id,
                    Length = busData.Length,
                    Width = busData.Width,
                    Model = busData.Model,
                    Name = busData.Name,
                    Seats = busData.Seats,
                    Localization = localizations[random.Next(0, 12)],
                    Passengers = new List<Passenger>()
                };
                for (int j = 0; j < random.Next(3, 14); j++)
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


        public static void ClearData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:31151/api/buses/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync("").Result;

            //  if (response.IsSuccessStatusCode)
            //{
            var dataObjects = response.Content.ReadAsStringAsync().Result;
            // }

            List<BusData> busesData = JsonConvert.DeserializeObject<List<BusData>>(dataObjects);


            foreach (BusData busData in busesData)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:31151/api/buses/" + busData.Id.ToString());
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(busData);

                //    streamWriter.Write(json);
                //    streamWriter.Flush();
                //    streamWriter.Close();
                //}

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
        }
    }
}
