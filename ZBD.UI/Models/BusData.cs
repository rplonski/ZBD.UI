using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBD.UI.Models
{
    public class BusData
    {
        public BusData()
        {

        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public int? Seats { get; set; }

        public string Localization { get; set; }

        public IList<Passenger> Passengers { get; set; }
    }
}
