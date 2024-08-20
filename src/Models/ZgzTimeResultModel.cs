using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.Models
{
    public class ZgzTimeResultModel
    {
        public string? type { get; set; }
        public List<Feature>? features { get; set; }
    }

    public class Feature
    {
        public string? type { get; set; }
        public Properties? properties { get; set; }
    }

    public class Properties
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? lastUpdated { get; set; }
        public string? link { get; set; }
        public string? icon { get; set; }
        public List<Destino>? destinos { get; set; }
        public string? gtfsId { get; set; }
    }

    public class Destino
    {
        public string? linea { get; set; }
        public string? destino { get; set; }
        public string? primero { get; set; }
        public string? segundo { get; set; }
    }
}
