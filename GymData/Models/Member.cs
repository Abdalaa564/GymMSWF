using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Member
    {
        [Key]
        public int Mid { get; set; }
        public string MName { get; set; } = string.Empty;
        public string MGen { get; set; } = string.Empty;
        public DateTime MDOB { get; set; }
        public DateTime MDate { get; set; }
        public string MPhone { get; set; } = string.Empty;
        public string MTiming { get; set; } = string.Empty;
        public string MStatus { get; set; } = string.Empty;

        public int? MMembershipId { get; set; }
        public Membership? MMembership { get; set; }

        public int? MCoachId { get; set; }
        public Coach? MCoach { get; set; }

        public ICollection<Finance> Finances { get; set; } = new List<Finance>();

        // One Member-to-One Coach
        // One Member-to-One Membership
    }
}
