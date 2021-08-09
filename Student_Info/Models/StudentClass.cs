using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Info.Models
{
    public class StudentClass
    {
        
        public int StudentClassId { get; set; }
        [Required, Display(Name = "Class Name"), StringLength(100)]
        public string ClassName { get; set; }
        public List<Student>Students{ get; set; }
    }
}
