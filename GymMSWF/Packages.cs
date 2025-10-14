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
    public partial class Packages : Form
    {
        private readonly PackageService _packageService;
        private List<GymData.Models.Package> _allPackages;
        public Packages()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _packageService = new PackageService(context);
        }


        private void DisplayPackages(List<GymData.Models.Package> packages)
        {
            flowPackages.Controls.Clear();

            foreach (var package in packages)
            {
                var card = new PackageCard(
                     package.pack_id,
                    package.pack_title,
                    package.pack_price,
                    package.pack_sessionsCount,
                    package.pack_desc,
                    package.pack_img
                );

                flowPackages.Controls.Add(card);
            }
        }

        public async Task LoadPackages()
        {
            flowPackages.Controls.Clear();

            _allPackages = await _packageService.GetAllPackages();
            DisplayPackages(_allPackages);
        }




        private async void Packages_Load(object sender, EventArgs e)
        {
            await LoadPackages();
        }

        private async void AddPackage_Click(object sender, EventArgs e)
        {
            using var addPackageForm = new AddPackageForm();

            if (addPackageForm.ShowDialog() == DialogResult.OK)
            {
                var newPackage = addPackageForm.NewPackage;

                if (newPackage != null)
                {
                   
                    _allPackages.Add(newPackage);

                   
                    var card = new PackageCard(
                        newPackage.pack_id,
                        newPackage.pack_title,
                        newPackage.pack_price,
                        newPackage.pack_sessionsCount,
                        newPackage.pack_desc,
                        newPackage.pack_img
                    );

                    flowPackages.Controls.Add(card);
                }
            }
        }

        private void searchPackage()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var filtered = _allPackages
                .Where(p => p.pack_title.ToLower().Contains(keyword))
                .ToList();

            DisplayPackages(filtered);
        }

        private void SearchPackage_Click(object sender, EventArgs e)
        {
            searchPackage();
        }
        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchPackage();
        }

        public void RemovePackageFromUI(int packageId)
        {
            // نحذف العنصر من القائمة في الذاكرة
            _allPackages.RemoveAll(p => p.pack_id == packageId);

            // نحذف الكارت من الواجهة فقط بدون إعادة تحميل الكل
            var cardToRemove = flowPackages.Controls
                .OfType<PackageCard>()
                .FirstOrDefault(c => (int)c.Tag == packageId);

            if (cardToRemove != null)
            {
                flowPackages.Controls.Remove(cardToRemove);
                cardToRemove.Dispose();
            }
        }


    }
}
