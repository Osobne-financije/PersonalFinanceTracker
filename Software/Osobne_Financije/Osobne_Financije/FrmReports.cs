using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                    to = today.AddDays(1).AddSeconds(-1);
                    break;
                case "Mjesec":
                    from = new DateTime(today.Year, today.Month, 1);
                    to = from.AddMonths(1).AddSeconds(-1);
                    break;
                case "6 mjeseci":
                    from = today.AddMonths(-6);
                    to = today.AddDays(1).AddSeconds(-1);
                    break;
                case "Godina":
                    from = today.AddYears(-1);
                    to = today.AddDays(1).AddSeconds(-1);
                    break;
                case "Određeno razdoblje":
                    from = dtpFrom.Value.Date;
                    to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
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
                FillPieChartForIncome(prihodi);
                ShowCategories();
            }
            else
            {
                ExpenseRepository expenseRepo = new ExpenseRepository();
                var troskovi = expenseRepo.GetExpensesByDateRange(studentId, from, to);
                dgvReport.DataSource = troskovi;
                FillPieChartForExpense(troskovi);
                ShowCategories();
            }
        }
        private void FillPieChartForIncome(List<Income> incomes)
        {
            chartReports.Series.Clear();
            Series series = new Series("Kategorije");
            series.ChartType = SeriesChartType.Pie;

            List<CategoryAmount> groupedData = new List<CategoryAmount>();
            foreach (var income in incomes)
            {
                var existing = groupedData.FirstOrDefault(x => x.CategoryName == income.CategoryName);
                if (existing != null)
                    existing.Amount += income.Amount;
                else
                    groupedData.Add(new CategoryAmount
                    {
                        CategoryName = income.CategoryName,
                        Amount = income.Amount
                    });
            }
            foreach (var item in groupedData)
            {
                series.Points.AddXY(item.CategoryName, item.Amount);
            }

            chartReports.Series.Add(series);
        }
        private void FillPieChartForExpense(List<Expense> expenses)
        {
            chartReports.Series.Clear();
            Series series = new Series("Kategorije");
            series.ChartType = SeriesChartType.Pie;

            List<CategoryAmount> groupedData = new List<CategoryAmount>();
            foreach (var expense in expenses)
            {
                var existing = groupedData.FirstOrDefault(x => x.CategoryName == expense.CategoryName);
                if (existing != null)
                    existing.Amount += expense.Amount;
                else
                    groupedData.Add(new CategoryAmount
                    {
                        CategoryName = expense.CategoryName,
                        Amount = expense.Amount
                    });
            }
            foreach (var item in groupedData)
            {
                series.Points.AddXY(item.CategoryName, item.Amount);
            }

            chartReports.Series.Add(series);
        }
        private void ShowCategories()
        {
            dgvReport.Columns["CategoryName"].HeaderText = "Kategorija";
            dgvReport.Columns["CategoryName"].DisplayIndex = 0;
            dgvReport.Columns["Amount"].HeaderText = "Iznos";
            dgvReport.Columns["Amount"].DisplayIndex = 1;
            dgvReport.Columns["Description"].HeaderText = "Opis";
            dgvReport.Columns["Description"].DisplayIndex = 2;
            dgvReport.Columns["Date"].HeaderText = "Datum";
            dgvReport.Columns["Date"].DisplayIndex = 3;
            dgvReport.Columns["Id"].Visible = false;
            dgvReport.Columns["StudentId"].Visible = false;
            dgvReport.Columns["CategoryId"].Visible = false;
        }
        private void lblMain_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }
        private void lblMain_MouseEnter(object sender, EventArgs e)
        {
            lblMain.Location = new Point(lblMain.Location.X - 5, lblMain.Location.Y);
            lblMain.Font = new Font(lblMain.Font.FontFamily, 13, FontStyle.Bold);
        }

        private void lblMain_MouseLeave(object sender, EventArgs e)
        {
            lblMain.Location = new Point(lblMain.Location.X + 5, lblMain.Location.Y);
            lblMain.Font = new Font(lblMain.Font.FontFamily, 11, FontStyle.Bold);
        }
        private void lblIncomes_Click(object sender, EventArgs e)
        {
            FrmIncome incomeForm = new FrmIncome();
            incomeForm.Show();
            this.Hide();
        }
        private void lblIncomes_MouseEnter(object sender, EventArgs e)
        {
            lblIncomes.Location = new Point(lblIncomes.Location.X - 5, lblIncomes.Location.Y);
            lblIncomes.Font = new Font(lblIncomes.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblIncomes_MouseLeave(object sender, EventArgs e)
        {
            lblIncomes.Location = new Point(lblIncomes.Location.X + 5, lblIncomes.Location.Y);
            lblIncomes.Font = new Font(lblIncomes.Font.FontFamily, 11, FontStyle.Bold);
        }
        private void lblExpenses_Click(object sender, EventArgs e)
        {
            FrmExpense expenseForm = new FrmExpense();
            expenseForm.Show();
            this.Hide();
        }
        private void lblExpenses_MouseEnter(object sender, EventArgs e)
        {
            lblExpenses.Location = new Point(lblExpenses.Location.X - 5, lblExpenses.Location.Y);
            lblExpenses.Font = new Font(lblExpenses.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblExpenses_MouseLeave(object sender, EventArgs e)
        {
            lblExpenses.Location = new Point(lblExpenses.Location.X + 5, lblExpenses.Location.Y);
            lblExpenses.Font = new Font(lblExpenses.Font.FontFamily, 11, FontStyle.Bold);
        }

    }
}
