using System.Collections.Generic;

namespace VirusHackKodShredinger.Repository
{
    public class People
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<Schedule> Schedules { get; set; }

    }
}