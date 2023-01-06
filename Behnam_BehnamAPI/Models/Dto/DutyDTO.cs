using System.ComponentModel.DataAnnotations;

namespace Behnam_BehnamAPI.Model
{
    public class DutyDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string Rate { get; set; }
        public string ImageUrl { get; set; }
        public int Sqft { get; set; }
    }
}
