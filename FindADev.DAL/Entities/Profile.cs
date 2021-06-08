using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }

        public int UserId { get; set; }

        public virtual Rate Rate { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<Knowledge> Knowledges { get; set; }
    }
}
