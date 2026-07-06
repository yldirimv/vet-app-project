using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VetMvc.Models
{
    [Table("Treatments")]
    public class TreatmentModel
    {
        [Key]
        public int TreatmentId { get; set; }
        public string TreatmentName { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public int PetId { get; set; }
        public int EmployeeId { get; set; }
        public int MedicineId { get; set; }

        [ForeignKey("PetId")]
        public PetModel Pet { get; set; }
        [ForeignKey("EmployeeId")]
        public EmployeeModel Employee { get; set; }
        [ForeignKey("MedicineId")]
        public MedicineModel Medicine { get; set; }
    }
}
