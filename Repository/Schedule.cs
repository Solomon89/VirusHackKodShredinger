using System;
using System.ComponentModel.DataAnnotations;

namespace VirusHackKodShredinger.Repository
{
    public class Schedule
    {
        public long Id { get; set; }

        public long PeopleId { get; set; }

        public long SubjectId { get; set; }

        [Display(Name = "Дата проведения")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Примечание")]
        public string Note { get; set; }

        public People People { get; set; }
        public Subject Subject { get; set; }

    }
}