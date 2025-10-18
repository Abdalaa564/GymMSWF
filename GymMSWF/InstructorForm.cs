using GymServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

                // Remove card when instructor deleted
                card.InstructorDeleted += (deletedCoach) =>
                {
                    flowLayoutPanel1.Controls.Remove(card);
                };

                flowLayoutPanel1.Controls.Add(card);
            }
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel1.Refresh();

        }
        public async void SearchMethod()
        {
            var searchedName = searchTextBox.Text.ToLower();
            var instructorList = await _coachService.GetAllCoaches();
            var filteredInstructors = instructorList
                .Where(i => i.ins_FName.ToLower().StartsWith(searchedName))
                .ToList();

            flowLayoutPanel1.Controls.Clear();

            foreach (var coach in filteredInstructors)
            {
                var card = new InstructorCard(coach)
                {
                    Margin = new Padding(10)
                };
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private  void searchIconButton_Click(object sender, EventArgs e)
        {
            SearchMethod();
        }

        private void AddInstructorBTN_Click(object sender, EventArgs e)
        {
            var addForm = new AddInstructor();

            addForm.InstructorAdded += (coach) =>
            {
                var card = new InstructorCard(coach)
                {
                    Margin = new Padding(10)
                };
                flowLayoutPanel1.Controls.Add(card);
            };

            addForm.ShowDialog();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchMethod();
        }
    }
}
