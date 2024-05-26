using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Models
{
    public class ImageData
    {
        [JsonProperty("large")]
        public string Large { get; set; }
    }
}
