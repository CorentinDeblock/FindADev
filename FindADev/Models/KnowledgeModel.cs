using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models
{
    public class KnowledgeModel
    {
        public int Id { get; set; }
        public KnowledgeType Type { get; set; }
        public int ProfileId { get; set; }

        public ProfileModel Profile { get; set; }
        public IEnumerable<KnowledgeInfoModel> Titles { get; set; }
    }
}
