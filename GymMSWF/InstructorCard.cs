using GymData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace GymMSWF
{
    public partial class InstructorCard : UserControl
    {
        public InstructorCard(Instructor coach)
        {
            InitializeComponent();

            insName.Text = $"{coach.ins_name}";
            // lblTitle.Text = coach.;
            insPhone.Text = coach.ins_phone;


            if (!string.IsNullOrEmpty(coach.ins_img))
            {
                insImage.Image = Image.FromFile(coach.ins_img);
                insImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
