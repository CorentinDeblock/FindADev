using FindADev.DAL.Enum;

namespace FindADev.ASP.Models
{
    public class KnowledgeInfoModel
    {
        public int Id { get; set; }
        public KnowledgeTitle Title { get; set; }
        public int Score { get; set; }
        public int KnowledgeId { get; set; }

        public KnowledgeModel Knowledge { get; set; }
    }
}