using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using eBooking_API.Models;

namespace eBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class HospitalController : ControllerBase
    {
        public MongoClient _client = null;
        public IMongoDatabase _db = null;
        public HospitalController(IConfiguration config)
        {
            _client = new MongoClient(config.GetValue<string>("eBookingDB:ConnectionString"));
            _db = _client.GetDatabase(config.GetValue<string>("eBookingDB:DatabaseName"));
        }
        [HttpGet("List")]
        public async Task<List<clshospital>> getAllHospList()
        {
            var hospData = _db.GetCollection<clshospital>("tbl_Hospital");
            List<clshospital> clshospital =await hospData.Find(hosp=>true).ToListAsync();
            return await Task.Run(() => {
                return clshospital;
            });
        }
    }
}