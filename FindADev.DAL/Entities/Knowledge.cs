using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL.Entities
{
    public class Knowledge
    {
        public int Id { get; set; }
        public KnowledgeType Type { get; set; }
        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual IEnumerable<KnowledgeInfo> Titles {get;set;}
    }
}
