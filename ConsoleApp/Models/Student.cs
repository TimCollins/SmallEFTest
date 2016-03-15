using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("StudentInfo")]
    public class Student
    {
        [Key]
        public int SID{ get; set; }

        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string StudentName { get; set; }

        [NotMapped]
        public int? Age { get; set; }
        
        public int StdId { get; set; }

        [ForeignKey("StdId")]
        public Standard Standard { get; set; }
    }
}
