using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBooking_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace eBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MapController : ControllerBase
    {
        public MongoClient _client = null;
        public IMongoDatabase _db = null;
        public MapController(IConfiguration config)
        {
            _client = new MongoClient(config.GetValue<string>("eBookingDB:ConnectionString"));
            _db = _client.GetDatabase(config.GetValue<string>("eBookingDB:DatabaseName"));
        }
        [HttpGet("getAllHosp")]
        public async Task<List<Map>> getAllHos()
        {
            var mapData = _db.GetCollection<Map>("tbl_Hospital");
            List<Map> clsmapData = await mapData.Find(hosp => true)
                .Project<Map>(
                Builders<Map>.Projection.Include(p => new { p.bed_ava, p.bed_occu, p.location, p.name })
                ).ToListAsync();

            return await Task.Run(() => {
                return clsmapData;
            });
        }
    }
}