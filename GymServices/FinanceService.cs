using GymData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
    public class FinanceService
    {
        private readonly GymContextDB _context;

        public FinanceService(GymContextDB context)
        {
            _context = context;
        }

        public (decimal Scheduled, decimal Paid, decimal Overdue) GetMonthlyFinanceSummary()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var records = _context.FinanceRecords
                .Where(f => f.RecordDate >= startOfMonth && f.RecordDate < endOfMonth)
                .ToList();

            if (!records.Any())
                return (0, 0, 0);

            decimal totalScheduled = records.Sum(f => f.ScheduledAmount);
            decimal totalPaid = records.Sum(f => f.PaidAmount);
            decimal totalOverdue = totalScheduled - totalPaid;

            return (totalScheduled, totalPaid, totalOverdue);
        }

        public decimal GetTodayPaid()
        {
            var today = DateTime.Today;
            return _context.FinanceRecords
                .Where(f => f.RecordDate.Date == today)
                .Sum(f => f.PaidAmount);
        }
    }
}
