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
    public partial class InstructorForm : Form
    {
        private readonly CoachService _coachService;
        public InstructorForm()
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);
        }

        private async void InstructorForm_Load(object sender, EventArgs e)
        {
            var result = await _coachService.GetAllCoaches();
            flowLayoutPanel1.Controls.Clear();

            foreach (var coach in result)
            {
                var card = new InstructorCard(coach)
                {
                    Margin = new Padding(10)
                };
                flowLayoutPanel1.Controls.Add(card);
            }

        }

        
    }
}
