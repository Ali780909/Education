using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class ProjectModel
    {
        public int Project_ID { get; set; }
        [Required(ErrorMessage = "  من فضلك ادخل اسم  المشروع ")]
        [MaxLength(100, ErrorMessage = " يجب ان يكون اقل من 100 حرف ")]
        public string Project_Name { get; set; }

        [Required(ErrorMessage = "  من فضلك ادخل رابط  المشروع ")]
        
        public string Project_Link { get; set; }
    }
}
