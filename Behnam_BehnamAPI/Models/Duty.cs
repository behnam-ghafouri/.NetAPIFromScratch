using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Behnam_BehnamAPI.Model
{
    public class Duty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public string ImageUrl { get; set; }
        public int Sqft { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
