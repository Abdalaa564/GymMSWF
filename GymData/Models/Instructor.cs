using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Instructor
    {
        [Key]
        public int ins_id { get; set; }

        public string ins_FName { get; set; } = string.Empty;
        public string ins_LName { get; set; } = string.Empty;
        public int ins_salary { get; set; }

        public string ins_title { get; set; } = string.Empty;


        public string ins_phone { get; set; } = string.Empty;
        public string ins_email { get; set; } = string.Empty;
        public string ins_gender { get; set; } = string.Empty;
        public string? ins_img { get; set; }
        public DateTime ins_birth { get; set; }
        public string ins_pass { get; set; } = string.Empty;

        public ICollection<Package> Packages { get; set; } = new List<Package>();
    }
}
