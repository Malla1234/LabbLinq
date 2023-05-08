using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabbLinq.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; } = 0;
        public string Subjects { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }
    }
}
