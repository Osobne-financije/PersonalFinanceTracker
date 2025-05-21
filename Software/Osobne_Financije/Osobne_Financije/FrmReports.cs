using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Osobne_Financije
{
    public partial class FrmReports: Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            cmbTimePeriod.Items.AddRange(new string[] { "Tjedan", "Mjesec", "6 mjeseci", "Godina", "Određeno razdoblje" });
            cmbTimePeriod.SelectedIndex = 0;

            cmbDataType.Items.AddRange(new string[] { "Prihodi", "Troškovi" });
            cmbDataType.SelectedIndex = 0;

            cmbTimePeriod.SelectedIndexChanged += cmbTimePeriod_SelectedIndexChanged;

        }

        private void cmbTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTimePeriod.SelectedItem.ToString() == "Određeno razdoblje")
            {
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
                lblFrom.Visible = true;
                lblTo.Visible = true;
            }
            else
            {
                dtpFrom.Visible = false;
                dtpTo.Visible = false;
                lblFrom.Visible = false;
                lblTo.Visible = false;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime from, to;
            DateTime today = DateTime.Today;

            switch (cmbTimePeriod.SelectedItem.ToString())
            {
                case "Tjedan":
                    from = today.AddDays(-7);
                    to = today;
                    break;
                case "Mjesec":
                    from = today.AddMonths(-1);
                    to = today;
                    break;
                case "6 mjeseci":
                    from = today.AddMonths(-6);
                    to = today;
                    break;
                case "Godina":
                    from = today.AddYears(-1);
                    to = today;
                    break;
                case "Određeno razdoblje":
                    from = dtpFrom.Value.Date;
                    to = dtpTo.Value.Date;
                    break;
                default:
                    MessageBox.Show("Odaberite vremensko razdoblje.");
                    return;
            }

            int studentId = Session.LoggedStudent.Id;

            if (cmbDataType.SelectedItem.ToString() == "Prihodi")
            {
                IncomeRepository incomeRepo = new IncomeRepository();
                var prihodi = incomeRepo.GetIncomesByDateRange(studentId, from, to);
                dgvReport.DataSource = prihodi;
            }
            else
            {
                ExpenseRepository expenseRepo = new ExpenseRepository();
                var troskovi = expenseRepo.GetExpensesByDateRange(studentId, from, to);
                dgvReport.DataSource = troskovi;
            }
        }
    }
}
