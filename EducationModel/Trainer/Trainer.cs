using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class Trainer
    {
        public Trainer()
        {
            this.Projects = new HashSet<Project>();
        }
        public int Trainer_ID { set; get; }
        public string Trainer_Name { set; get; }
        public int Age { set; get; }
        public string? Address { set; get; }
        public string? Mobile { set; get; }
        public int User_Id { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
