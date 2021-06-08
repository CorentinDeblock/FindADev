using FindADev.DAL.Entities;
using System.Collections.Generic;

namespace FindADev.ASP.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }

        public int UserId { get; set; }

        public RateModel Rate { get; set; }
        public UserModel User { get; set; }
        public IEnumerable<KnowledgeModel> Knowledges { get; set; }
    }
}
