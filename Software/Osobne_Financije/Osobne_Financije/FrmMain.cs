using DBLayer;
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
    public partial class FrmMain: Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShowSummary();
            LoadChart();
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

        private void ShowSummary()
        {
            var incomeRepo = new IncomeRepository();
            var expenseRepo = new ExpenseRepository();

            int studentId = Session.LoggedStudent.Id;

            decimal totalIncome = incomeRepo.GetTotalIncomeByStudentId(studentId);
            decimal totalExpense = expenseRepo.GetTotalExpenseByStudentId(studentId);
            decimal balance = totalIncome - totalExpense;

            lblTotalIncomes.Text = totalIncome.ToString("0.00") + " €";
            lblTotalExpenses.Text = totalExpense.ToString("0.00") + " €";
            label2.Text = balance.ToString("0.00") + " €";
        }

        private void LoadChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Prihodi");
            chart1.Series.Add("Troskovi");

            chart1.Series["Prihodi"].ChartType = SeriesChartType.Column;
            chart1.Series["Troskovi"].ChartType = SeriesChartType.Column;


            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            chart1.ChartAreas[0].AxisX.Minimum = 0.5;
            chart1.ChartAreas[0].AxisX.Maximum = daysInMonth + 0.5;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Title = "Dan u mjesecu";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0";

            chart1.ChartAreas[0].AxisY.Title = "Iznos (€)";
          
            int studentId = Session.LoggedStudent.Id;

            var incomeRepo = new IncomeRepository();
            var expenseRepo = new ExpenseRepository();

            List<DailyAmount> incomeData = incomeRepo.GetIncomesForCurrentMonth(studentId);
            List<DailyAmount> expenseData = expenseRepo.GetExpensesForCurrentMonth(studentId);

            for (int day = 1; day <= daysInMonth; day++)
            {
                var income = incomeData.FirstOrDefault(x => x.Day == day)?.Amount ?? 0;
                var expense = expenseData.FirstOrDefault(x => x.Day == day)?.Amount ?? 0;

                chart1.Series["Prihodi"].Points.AddXY(day, income);
                chart1.Series["Troskovi"].Points.AddXY(day, expense);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.LoggedStudent = null;
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
            this.Close();
        }

        private void lblReports_Click(object sender, EventArgs e)
        {
            FrmReports reportForm = new FrmReports();
            reportForm.Show();
            this.Hide();
        }
        private void lblReports_MouseEnter(object sender, EventArgs e)
        {
            lblReports.Location = new Point(lblReports.Location.X - 5, lblReports.Location.Y);
            lblReports.Font = new Font(lblReports.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblReports_MouseLeave(object sender, EventArgs e)
        {
            lblReports.Location = new Point(lblReports.Location.X + 5, lblReports.Location.Y);
            lblReports.Font = new Font(lblReports.Font.FontFamily, 11, FontStyle.Bold);
        }
    }
}
