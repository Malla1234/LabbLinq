using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabbLinq.Models
{
    public class StudentClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentClassId { get; set; } = 0;
        public string ClassName { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }
    }
}
