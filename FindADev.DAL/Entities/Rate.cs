using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public WorkDate WorkDate {get;set;} 
        public int WorkTime { get; set; }
        public int Prices { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
