using System.ComponentModel;

namespace LabbLinq.Models
{
    public class SearchViewModel
    {
        public int Id { get; set; }

        [DisplayName("Teacher's First Name")]
        public string TeacherFirstName { get; set; }
        [DisplayName("Teacher's Last Name")]
        public string TeacherLastName { get; set; }

        [DisplayName("Student's First Name")]
        public string StudentFirstName { get; set; }
        [DisplayName("Student's Last Name")]
        public string StudentLastName { get; set; }

        [DisplayName("Courses")]
        public string Subjects { get; set; }
    }
    //[DisplayName("Teachers First Name")]
    //public string FirstName { get; set; }
    //[DisplayName("Teachers Last Name")]
    //public string LastName { get; set; }

    //[DisplayName("Student First Name")]
    //public string FirstName { get; set; }
    //[DisplayName("Student Last Name")]
    //public string LastName { get; set; }

    //[DisplayName("Corses")]
    //public string Subjects { get; set; }
    ////[DisplayName("Class")]
    ////public string ClassName { get; set; }
    ///
}
