using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class Project
    {
        public Project()
        {
            
        }

        public int Trainer_ID { get; set; }
        public int Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Project_Link { get; set; }
        public virtual Trainer Trainer { get; set; }
        public int Student_Id { get; set; }
      /*  [Required]
        [ForeignKey("Student_ID")]*/
        public int Teacher_Id { get; set; }
        //[Required]
        //[ForeignKey("Teacher_ID")]
        public virtual Student student { get; set; }
        public virtual Teacher teacher { get; set; }

        public virtual Trainer trainers { get; set; }

    
       




    }
}
