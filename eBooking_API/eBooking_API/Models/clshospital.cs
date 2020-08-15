using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eBooking_API.Models
{
    public class clshospital
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("Mob_Num")]
        public string Mob_Num { get; set; }
        [BsonElement("bed_ava")]
        public string bed_ava { get; set; }
        [BsonElement("bed_occ")]
        public string bed_occ { get; set; }
        [BsonElement("services")]
        public List<string> services { get; set; }
        [BsonElement("rating")]
        public int rating { get; set; }
        [BsonElement("lat")]
        public string lat { get; set; }
        [BsonElement("lon")]
        public string lon { get; set; }
    }
}
