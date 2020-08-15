using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBooking_API.Models
{
    public class Map
    {
        [BsonElement("geo_loc")]
        public geo_loc location { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("bed_ava")]
        public string bed_ava { get; set; }
        [BsonElement("bed_occ")]
        public string bed_occu { get; set; }

    }
    public class geo_loc
    {
        public string lat { get; set; }
        public string lon { get; set; }
    }
}
