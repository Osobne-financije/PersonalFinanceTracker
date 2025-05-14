using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osobne_Financije
{
    public partial class FrmMain: Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void lblIncomes_Click(object sender, EventArgs e)
        {
            FrmIncome incomeForm = new FrmIncome();
            incomeForm.Show();
            this.Hide();
        }
        private void lblIncomes_MouseEnter(object sender, EventArgs e)
        {
            lblIncomes.Location = new Point(lblIncomes.Location.X -5, lblIncomes.Location.Y);
            lblIncomes.Font = new Font(lblIncomes.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblIncomes_MouseLeave(object sender, EventArgs e)
        {
            lblIncomes.Location = new Point(lblIncomes.Location.X + 5, lblIncomes.Location.Y);
            lblIncomes.Font = new Font(lblIncomes.Font.FontFamily, 11, FontStyle.Bold);
        }
    }
}
