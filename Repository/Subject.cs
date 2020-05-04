using System.Collections.Generic;

namespace VirusHackKodShredinger.Repository
{
    public class Subject
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}