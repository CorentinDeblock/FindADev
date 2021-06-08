using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models.Form
{
    public class KnowledgeForm
    {
        public int Id { get; set; }
        public KnowledgeType Type { get; set; }
        public int ProfileId { get; set; }
    }
}
