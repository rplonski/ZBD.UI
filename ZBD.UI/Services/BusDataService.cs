using Newtonsoft.Json;
using System;
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
    }
}
