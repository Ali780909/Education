using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EducationModel
{
    public class User : IdentityUser
    { 
        public int User_Id { get; set; }
        public int Teacher_ID { get; set; }
        public int Trainer_ID { get; set; }
        public int Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public virtual Student students { get; set; }
        public virtual Teacher teachers { get; set; }
        public virtual Trainer trainers { get; set; }


    }
}
