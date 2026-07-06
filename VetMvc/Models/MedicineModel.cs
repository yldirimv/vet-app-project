using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VetMvc.Models
{
    [Table("Medicines")]
    public class MedicineModel
    {
        [Key]
        public int MedicineId { get; set; }
        public string MedName { get; set; }
        public string UsageDescription { get; set; }
        public string MedicineType { get; set; }
    }
}
