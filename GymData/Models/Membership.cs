using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Membership
    {
        [Key]
        public int MShipId { get; set; }
        public string MName { get; set; } = string.Empty;
        public int MDuration { get; set; }
        public string MGoal { get; set; } = string.Empty;
        public decimal MCost { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>(); //One-to-Many
    }
}
