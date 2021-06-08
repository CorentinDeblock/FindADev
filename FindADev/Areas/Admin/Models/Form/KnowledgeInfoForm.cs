using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models.Form
{
    public class KnowledgeInfoForm
    {
        public int Id { get; set; }
        [Required]
        public KnowledgeTitle Title { get; set; }
        [Required]
        public int Score { get; set; }
        public int KnowledgeId { get; set; }
    }
}
