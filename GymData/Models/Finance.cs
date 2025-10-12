using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Finance
    {
        [Key]
        public int BillId { get; set; }

        public int? AgentId { get; set; }
        public Receptionist? Agent { get; set; }

        public int? MemberId { get; set; }
        public Member? Member { get; set; }

        public string BPeriod { get; set; } = string.Empty;
        public DateTime BDate { get; set; }
        public decimal BAmount { get; set; }

        //Many-to-One Receptionist, Members
    }
}
