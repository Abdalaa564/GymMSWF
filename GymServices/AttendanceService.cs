using GymData;
using GymData.Models;
using GymServices.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GymServices
{
    public class AttendanceService
    {
        private readonly GymContextDB _context;

        public AttendanceService(GymContextDB context)
        {
            _context = context;
        }

        public int GetTodayAttendanceCount(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return _context.Attendances
                .Count(a => a.AttendanceDate >= startOfDay && a.AttendanceDate < endOfDay);
        }

        public List<Attendance> GetLastAttendances(int count)
        {
            return _context.Attendances
                .Include(a => a.Client)
                .OrderByDescending(a => a.AttendanceDate)
                .Take(count)
                .ToList();
        }

        public int GetAttendanceCountByClient(int clientId)
        {
            return _context.Attendances
                .Count(a => a.MemberId == clientId);
        }

        public List<PackageInfoDTO> GetAllPackagesWithInstructor()
        {
            var data = _context.package
            .Include(p => p.Instructor)
            .Include(p => p.Members)
            .Select(p => new PackageInfoDTO
            {
                PackageName = p.pack_title,
                InstructorName = p.Instructor != null ? p.Instructor.FullName : "N/A",
                StartDate = p.Members
                    .OrderBy(m => m.startDate)
                    .Select(m => m.startDate)
                    .FirstOrDefault()
            })
            .ToList();

            return data;
        }

        public ClientAttendanceSummaryDTO GetClientAttendanceSummary(int clientId)
        {
            var client = _context.client
                .Include(c => c.Package)
                .Include(c => c.Payments)
                .FirstOrDefault(c => c.client_id == clientId);

            if (client == null)
                return null;

            var attendedCount = _context.Attendances
                .Count(a => a.MemberId == clientId);

            var lastSession = _context.Attendances
                .Where(a => a.MemberId == clientId)
                .OrderByDescending(a => a.AttendanceDate)
                .FirstOrDefault();

            return new ClientAttendanceSummaryDTO
            {
                ClientName = client.client_name,
                PackageName = client.Package?.pack_title ?? "No Package",
                JoinDate = client.startDate,
                EndDate = client.endDate,
                TotalSessions = client.Package?.pack_sessionsCount ?? 0,
                AttendedSessions = attendedCount,
                LastAttendanceDate = lastSession?.AttendanceDate,
                CurrentAttendanceTime = DateTime.Now
            };
        }

    }
}
