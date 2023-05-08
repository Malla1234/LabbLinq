using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabbLinq.Models
{
    public class SchoolConnection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolConnectionId { get; set; }

        [ForeignKey("Teachers")]
        public int FK_TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; } = default!;

        [ForeignKey("Students")]
        public int FK_StudentId { get; set; }
        public virtual Student Students { get; set; } = default!;

        [ForeignKey("Courses")]
        public int FK_CourseId { get; set; }
        public virtual Course Courses { get; set; } = default!;

        [NotMapped]
        public string Subject { get; set; }

        [ForeignKey("StudentClasses")]
        public int FK_StudentClassId { get; set; }
        public virtual StudentClass StudentClasses { get; set; } = default!;
    }
}
