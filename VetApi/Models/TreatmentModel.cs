namespace VetApi.Models
{
    public class TreatmentModel
    {
        public int TreatmentId { get; set; }
        public string TreatmentName { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public int PetId { get; set; }
        public int EmployeeId { get; set; }
        public int MedicineId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string NameSurname { get; set; }
    }
}
