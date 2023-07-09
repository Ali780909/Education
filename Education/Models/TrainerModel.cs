using System.ComponentModel.DataAnnotations;

namespace Education
{
    public class TrainerModel 
    {
        public int Trainer_ID { get; set; }

        [Required(ErrorMessage = "  من فضلك ادخل اسم المدرب")]
        [MaxLength(100, ErrorMessage = " يجب ان يكون اقل من 100 حرف ")]
        public string Trainer_Name { get; set; }

    }
}
