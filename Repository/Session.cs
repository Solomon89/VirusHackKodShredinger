using System;

namespace VirusHackKodShredinger.Repository
{
    public class Session
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long StudentId { get; set; }
        
        public DateTime TimeStamp { get; set; }

        public double State1 { get; set; }
        public double State2 { get; set; }
    }
}