using GymData.Models;
using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class EquipmentCard : UserControl
    {
        private readonly EquipmentService _equipmentService;
        public EquipmentCard()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _equipmentService = new EquipmentService(context);

            var equipments = _equipmentService.GetAll();
        }

        public void SetData(Equipment equipment)
        {
            EquipmentName.Text = equipment.EquipName;
            Category.Text = equipment.Category;
            Quantity.Text = equipment.Quantity.ToString();
            Price.Text = equipment.Price.ToString("C");
            PurchaseDate.Text = equipment.PurchaseDate.ToShortDateString();
            Condition.Text = equipment.Condition;
            MaintenanceDate.Text = equipment.MaintenanceDate?.ToShortDateString() ?? "N/A";
            EquipDescription.Text = equipment.EquipDescription;
            EmployeeId.Text = equipment.EmployeeId?.ToString() ?? "N/A";

            //if (equipment.EquipImage != null && equipment.EquipImage.Length > 0)
            //{
            //    byte[] imageBytes = Convert.FromBase64String(equipment.EquipImage);

            //    using (var ms = new MemoryStream(imageBytes))
            //    {
            //        EquipImage.Image = Image.FromStream(ms);
            //    }
            //}
        }
    }
}
