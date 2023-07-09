using EducationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class  Teacher
    {
        public int Teacher_ID { set; get; }
        public string Teacher_Name { set; get; }
        public int Age { set; get; }
        public string Address { set; get; }
        public string Mobile { set; get; }
        public int ProjectID { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<Project> project { get; set; }
    }
}
