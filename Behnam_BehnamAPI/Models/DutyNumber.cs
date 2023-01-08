using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Behnam_BehnamAPI.Model
{
    public class DutyNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int DutyNo { get; set; }
        [ForeignKey("Duty")]
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
