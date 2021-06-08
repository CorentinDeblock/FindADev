using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models.Form
{
    public class RateForm
    {
        public int Id { get; set; }

        [Required]
        public WorkDate WorkDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int WorkTime { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Prices { get; set; }

        public int ProfileId { get; set; }
    }
}
