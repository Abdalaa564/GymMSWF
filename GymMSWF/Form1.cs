
using GymServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace GymMSWF
{
    public partial class Form1 : Form
    {
        private readonly CoachService _coachService;
        public Form1()
        {

            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
