using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirusHackKodShredinger.Repository;

namespace VirusHackKodShredinger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private const int BeautyFactor = 4;
        private readonly ApplicationContext _context;

        public SessionController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("UpdateState")]
        public async Task<IActionResult> UpdateState(UpdateStateRequest request)
        {
            var session = new Session()
            {
                JobId = request.JobId,
                StudentId = request.StudentId,
                State1 = request.State1,
                State2 = request.State2,
                TimeStamp = request.TimeStamp ?? DateTime.Now
            };
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("State")]
        public IActionResult GetState(long jobId)
        {
            var collection = _context.Sessions.Where(x => x.JobId == jobId)
                .AsEnumerable()
                .GroupBy(
                    x => x.StudentId,
                (_, sessions) => sessions.OrderByDescending(x => x.TimeStamp).First().State1)
                .ToList();

            var collectionCount = collection.Any()
                ? collection.Sum(x => (float) x) / (collection.Count * BeautyFactor) * 100
                : -1;

            return new JsonResult(MathF.Round(collectionCount, 2));
        }
    }

    public class UpdateStateRequest
    {
        public long JobId { get; set; }
        public long StudentId { get; set; }
        public float State1 { get; set; }
        public float State2 { get; set; }

        public DateTime? TimeStamp { get; set; }
    }

}