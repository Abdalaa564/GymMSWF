using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Coach
    {
        [Key]
        public int Cid { get; set; }
        public string CName { get; set; } = string.Empty;
        public DateTime CDOB { get; set; }
        public string CPhone { get; set; } = string.Empty;
        public int CExperience { get; set; }
        public string CAddress { get; set; } = string.Empty;
        public string CPass { get; set; } = string.Empty;

        public ICollection<Member> Members { get; set; } = new List<Member>(); // One-to-Many
    }
}
