using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace job_site.Models
{
    public class Vacancy
    {
        public long? VacancyID { get; set; }               
        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;   
        public string Location { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salary { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}