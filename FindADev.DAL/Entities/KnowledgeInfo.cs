using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL.Entities
{
    public class KnowledgeInfo
    {
        public int Id { get; set; }
        public KnowledgeTitle Title { get; set; }
        public int Score { get; set; }
        public int KnowledgeId { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}
