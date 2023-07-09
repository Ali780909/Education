using System.ComponentModel.DataAnnotations;

namespace Education
{
    public class TeacherModel
    {
        public int Teacher_ID { get; set; }

        [Required(ErrorMessage = " من فضلك ادخل اسم المعلم")]
        [MaxLength(100, ErrorMessage = " يجب ان يكون اقل من 100 حرف ")]
        public string Teacher_Name { get; set; }

        [Required(ErrorMessage = " من فضلك ادخل اسم  المشروع الخاص بالمعلم")]
        public string Project { get; set; }
    }
}
