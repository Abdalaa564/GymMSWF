using GymData;
using GymData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
    public class EquipmentService
    {
        private readonly GymContextDB _context;

        public EquipmentService(GymContextDB context)
        {
            _context = context;
        }

        public List<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public Equipment GetById(int id)
        {
            return _context.Equipments.FirstOrDefault(e => e.EquipmentId == id);
        }

        public void Add(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
        }

        public void Update(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var equipment = _context.Equipments.Find(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
                _context.SaveChanges();
            }
        }

    }
}
