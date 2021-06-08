using FindADev.DAL.Enum;

namespace FindADev.ASP.Models
{
    public class RateModel
    {
        public int Id { get; set; }
        public WorkDate WorkDate { get; set; }
        public int WorkTime { get; set; }
        public int Prices { get; set; }

        public int ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
