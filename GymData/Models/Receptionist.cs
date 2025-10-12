using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Receptionist
    {
        [Key]
        public int Rsccptid { get; set; }
        public string RecepName { get; set; } = string.Empty;
        public string RecepGen { get; set; } = string.Empty;
        public DateTime RecepDOB { get; set; }
        public string RecepAdd { get; set; } = string.Empty;
        public string RecepPhone { get; set; } = string.Empty;
        public string RecepPass { get; set; } = string.Empty;

        public ICollection<Finance> Finances { get; set; } = new List<Finance>();
    }
}
