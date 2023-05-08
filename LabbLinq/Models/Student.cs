using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LabbLinq.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }
    }
}
