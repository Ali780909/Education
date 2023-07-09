using System.ComponentModel.DataAnnotations;

namespace Education
{
    public class StudentModel
    {
        public int Student_ID { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل اسم الطالب")]
        [MaxLength(100, ErrorMessage = " يجب ان يكون اقل من 100 حرف ")]
        public string Student_Name { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل عمر الطالب")]
        public int Student_Age { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل اسم المدرسه")]
        [MaxLength(100, ErrorMessage = " يجب ان يكون اقل من 100 حرف ")]
        public string SchoolName { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل  مشروع الطالب")]
        public string Project { get; set; }

    }
}
