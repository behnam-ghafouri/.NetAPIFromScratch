using System.ComponentModel.DataAnnotations;

namespace Behnam_BehnamAPI.Model
{
    public class DutyNumberDTO
    {
        [Required]
        public int DutyNo { get; set; }
        [Required]
        public int DutyId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
