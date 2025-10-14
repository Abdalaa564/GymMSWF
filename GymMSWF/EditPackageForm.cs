using GymData;
using GymData.Models;
using GymServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Package = GymData.Models.Package;

namespace GymMSWF
{
    public partial class EditPackageForm : Form
    {
        private readonly PackageService _packageService;
        private readonly GymContextDB _context;
        private Package _package;


        public EditPackageForm(int packageId)
        {
            InitializeComponent();
            _context = DbContext.CreateDbContext();
            _packageService = new PackageService(_context);
            LoadPackageData(packageId);
        }

        private void LoadPackageData(int id)
        {
            _package = _packageService.GetPackageById(id);
            if (_package == null)
            {
                MessageBox.Show("Package not found!");
                this.Close();
                return;
            }

            txtTitle.Text = _package.pack_title;
            txtPrice.Text = _package.pack_price.ToString();
            txtSessions.Text = _package.pack_sessionsCount.ToString();
            txtDescription.Text = _package.pack_desc;

            if (File.Exists(_package.pack_img))
                picPackage.Image = Image.FromFile(_package.pack_img);
        }
        public Package UpdatedPackage { get; private set; }


        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                _package.pack_title = txtTitle.Text;
                _package.pack_price = decimal.Parse(txtPrice.Text);
                _package.pack_sessionsCount = int.Parse(txtSessions.Text);
                _package.pack_desc = txtDescription.Text;

                if (comboEditInstructor.SelectedValue != null)
                {
                    //edit this
                    _package.ins_id = (int)comboEditInstructor.SelectedValue;
                }

                await _packageService.UpdatePackageAsync(_package);

                UpdatedPackage = _package;

                MessageBox.Show("✅ Package updated successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picPackage.Image = Image.FromFile(openFile.FileName);
                _package.pack_img = openFile.FileName;
            }
        }

        private void EditPackageForm_Load(object sender, EventArgs e)
        {

            var context = DbContext.CreateDbContext();
            var instructors = context.instructors.ToList();

            comboEditInstructor.DataSource = instructors;
            comboEditInstructor.DisplayMember = "FullName";
            comboEditInstructor.ValueMember = "ins_id";

            txtTitle.Text = _package.pack_title;
            txtDescription.Text = _package.pack_desc;
            txtPrice.Text = _package.pack_price.ToString();
            txtSessions.Text = _package.pack_sessionsCount.ToString();

            if (File.Exists(_package.pack_img))
                picPackage.Image = Image.FromFile(_package.pack_img);

            
            comboEditInstructor.SelectedValue = _package.ins_id;
        }
    }
}

