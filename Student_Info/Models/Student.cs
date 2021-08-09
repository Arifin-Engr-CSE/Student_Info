using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Info.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required,Display(Name ="Student Name"),StringLength(100)]
        public string StudentName { get; set; }
        [Required, Display(Name = "Address")]
        public string Address { get; set; }
        [Required, Display(Name = "Date of Addmission")]
        public DateTime AddmissionDate { get; set; }
        [ForeignKey("StudentClass")]
        [Required, Display(Name = "Class")]
        public int StudentClassId { get; set; }
        
        public StudentClass StudentClass { get; set; }

    }
}
