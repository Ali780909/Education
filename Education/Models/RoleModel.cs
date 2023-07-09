using System.ComponentModel.DataAnnotations;

namespace Education
{
    public class RoleModel
    {

        public string Id { get; set; }
        [Display(Name = "Role")]

        [Required, MaxLength(10), MinLength(4)]
        public string Name { get; set; }
    }
}
