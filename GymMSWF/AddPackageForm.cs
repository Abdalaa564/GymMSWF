using GymData;
using GymData.Models;
using GymServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class AddPackageForm : Form
    {
        private readonly PackageService _packageService;
        private readonly GymContextDB _context;
        private string _selectedImagePath = string.Empty;

        public Package NewPackage { get; private set; }

        public AddPackageForm()
        {
            InitializeComponent();
            _context = DbContext.CreateDbContext();
            _packageService = new PackageService(_context);
        }

        private void AddPackageForm_Load(object sender, EventArgs e)
        {
            var instructors = _context.instructors.ToList();

            comboInstructors.DataSource = instructors;
            comboInstructors.DisplayMember = "FullName";
            comboInstructors.ValueMember = "ins_id";


            comboInstructors.SelectedIndex = -1;
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PictureAddPack.Image = Image.FromFile(openFile.FileName);
                    _selectedImagePath = openFile.FileName;
                }
            }
        }

        private async void SaveNewPackage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtcountSession.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrEmpty(_selectedImagePath) ||
                comboInstructors.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Please fill all fields before saving.");
                return;
            }

           
            int selectedInstructorId = 0;

            var selectedInstructor = comboInstructors.SelectedItem as Instructor;
            if (selectedInstructor != null)
            {
                selectedInstructorId = selectedInstructor.ins_id;
            }
            else if (comboInstructors.SelectedValue != null)
            {
                int.TryParse(comboInstructors.SelectedValue.ToString(), out selectedInstructorId);
            }

            
            

            var newPackage = new Package
            {
                pack_title = txtTitle.Text.Trim(),
                pack_sessionsCount = int.Parse(txtcountSession.Text),
                pack_price = decimal.Parse(txtPrice.Text),
                pack_desc = txtDescription.Text.Trim(),
                pack_img = _selectedImagePath,
                ins_id = selectedInstructorId
            };

            await _packageService.AddPackageAsync(newPackage);

            MessageBox.Show("✅ Package added successfully!");
            NewPackage = newPackage;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
