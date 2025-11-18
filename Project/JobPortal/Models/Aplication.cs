using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Application
    {
        public long ApplicationID { get; set; }

        [Required(ErrorMessage = "Вкажіть своє ім'я")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "Вкажіть Email")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string Email { get; set; }

        public string Message { get; set; }

        public long VacancyID { get; set; }
    }
}
