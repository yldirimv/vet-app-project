using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VetMvc.Models
{
    [Table("Pets")]
    public class PetModel
    {
        [Key]
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string OwnerPhone { get; set; }
    }
}
