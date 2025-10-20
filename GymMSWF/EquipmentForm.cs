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
    public partial class EquipmentForm : Form
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentForm()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _equipmentService = new EquipmentService(context);
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            LoadEquipments();
        }

        private void LoadEquipments()
        {
            flowEquipments.Controls.Clear();
            var equipments = _equipmentService.GetAll();

            foreach (var equipment in equipments)
            {
                EquipmentCard card = new EquipmentCard();
                card.SetData(equipment);

                card.Margin = new Padding(10);
                flowEquipments.Controls.Add(card);
            }
        }
    }
}
