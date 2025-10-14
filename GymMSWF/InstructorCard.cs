using GymData.Models;
using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class InstructorCard : UserControl
    {
        private readonly Instructor _coach;
        private readonly CoachService _coachService;
        public event Action<Instructor> InstructorDeleted;

        public InstructorCard(Instructor coach)
        {
            InitializeComponent();
            _coach = coach;
            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);

            insName.Text = $"{coach.ins_FName}";
            insLname.Text = $"{coach.ins_LName}";
            insTitle.Text = coach.ins_title;
            insPhone.Text = coach.ins_phone;

            if (!string.IsNullOrEmpty(coach.ins_img) && File.Exists(coach.ins_img))
            {
                insImage.Image = Image.FromFile(coach.ins_img);
                insImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void deleteInsIconButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Are you sure you want to delete {_coach.ins_FName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _coachService.DeleteCoach(_coach.ins_id);
                    InstructorDeleted?.Invoke(_coach);
                    this.Dispose();
                    MessageBox.Show("Instructor deleted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting instructor: {ex.Message}");
                }
            }
        }

        private void editIconButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditInstructorForm(_coach);
            editForm.InstructorUpdated += (updatedCoach) =>
            {
                insName.Text = updatedCoach.ins_FName;
                insLname.Text = updatedCoach.ins_LName;
                insTitle.Text = updatedCoach.ins_title;
                insPhone.Text = updatedCoach.ins_phone;

                if (!string.IsNullOrEmpty(updatedCoach.ins_img) && File.Exists(updatedCoach.ins_img))
                {
                    insImage.Image = Image.FromFile(updatedCoach.ins_img);
                }
            };

            editForm.ShowDialog();
        }
    }
}
