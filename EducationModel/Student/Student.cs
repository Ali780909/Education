using EducationModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class Student  
    {
        public int Student_ID { set; get; }
        public string Student_Name { set; get; }
        public int Student_Age { set; get; }
        public string Address { set; get; }
        public string SchoolName { set; get; }
        public int Grade { set; get; }
        public virtual User Users { get; set; }
        public virtual ICollection< Project>  project { get; set; }


    }
}
