using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Models
{
    public class Place
    {
        [JsonIgnore]
        public int id { get; set; }

        [JsonPropertyName("response")]
        public Response response { get; set; }

        public class Response
        {
            [JsonIgnore]
            public int id { get; set; }
            [JsonPropertyName("venues")]
            public  List<Venues> venues { get; set; }
        }   

        public class Venues
        {
            [JsonIgnore]
            public int id { get; set; }
            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("location")]
            public Location location { get; set; }

            [JsonPropertyName("categories")]
            public List<Categories> categories { get; set; }


        }

        public class Location
        {
            [JsonIgnore]
            public int id { get; set; }
            [JsonPropertyName("lat")]
            public float lat { get; set; }
            [JsonPropertyName("lng")]
            public float lng { get; set; }
            [JsonPropertyName("distance")]
            public int distance { get; set; }
        }

        public class Categories
        {
            [JsonIgnore]
            public int id { get; set; }
            [JsonPropertyName("name")]
            public string categoryName { get; set; }
        }
    }
}
