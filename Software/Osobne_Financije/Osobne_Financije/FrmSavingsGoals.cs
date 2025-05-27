using DBLayer;
using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
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
    public partial class FrmSavingsGoals: Form
    {
        public FrmSavingsGoals()
        {
            InitializeComponent();
        }

        private void FrmSavingsGoals_Load(object sender, EventArgs e)
        {
            CategoryRepository catRepo = new CategoryRepository();
            var expenseCategories = catRepo.GetCategoriesByType("Expense");
            cmbCategories.DataSource = expenseCategories;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "Id";

            SavingsGoalRepository goalRepo = new SavingsGoalRepository();
            var goal = goalRepo.GetGoalByStudentId(Session.LoggedStudent.Id);
            if (goal != null)
                txtSavingsGoal.Text = goal.TargetAmount.ToString("0.00") + " €";
            else
                txtSavingsGoal.Text = "Nema cilja";

            IncomeRepository incomeRepo = new IncomeRepository();
            ExpenseRepository expenseRepo = new ExpenseRepository();

            decimal totalIncome = incomeRepo.GetTotalIncomeByStudentId(Session.LoggedStudent.Id);
            decimal totalExpense = expenseRepo.GetTotalExpenseByStudentId(Session.LoggedStudent.Id);
            decimal currentSavings = totalIncome - totalExpense;

            txtCurrentSavings.Text = currentSavings.ToString("0.00") + " €";
            ShowLimits();
        }

        private void ShowLimits()
        {
            int studentId = Session.LoggedStudent.Id;

            CategoryLimitRepository limitRepo = new CategoryLimitRepository();
            ExpenseRepository expenseRepo = new ExpenseRepository();

            var limits = limitRepo.GetLimitsByStudentId(studentId);
            var expenses = expenseRepo.GetExpenseByStudentId(studentId);
            List<LimitReport> reportList = new List<LimitReport>();

            foreach (var limit in limits)
            {
                decimal totalSpent = expenses
                    .Where(e => e.CategoryId == limit.CategoryId)
                    .Sum(e => e.Amount);

                if (totalSpent > limit.LimitAmount)
                {
                    MessageBox.Show($"Upozorenje: Prekoračen limit za kategoriju \"{limit.CategoryName}\"!", "Prekoračenje limita", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                reportList.Add(new LimitReport
                {
                    CategoryName = limit.CategoryName,
                    LimitAmount = limit.LimitAmount,
                    Spent = totalSpent
                });
            }
            dgvLimits.DataSource = null;
            dgvLimits.DataSource = reportList;
            dgvLimits.Columns["CategoryName"].HeaderText = "Kategorija";
            dgvLimits.Columns["LimitAmount"].HeaderText = "Limit";
            dgvLimits.Columns["Spent"].HeaderText = "Potrošeno";
            dgvLimits.Columns["Remaining"].HeaderText = "Preostalo";
        }


        private void btnGoal_Click(object sender, EventArgs e)
        {
            string amounttxt = txtGoalAmount.Text.Trim();

            if (string.IsNullOrEmpty(amounttxt))
            {
                MessageBox.Show("Unesite iznos cilja štednje.");
                return;
            }
            if (!decimal.TryParse(amounttxt, out decimal amount))
            {
                MessageBox.Show("Unesite ispravan iznos.");
                return;
            }
            SavingsGoalRepository repo = new SavingsGoalRepository();
            string deleteQuery = $"DELETE FROM SavingsGoals WHERE StudentId = {Session.LoggedStudent.Id}";

            DB.OpenConnection();
            DB.ExecuteCommand(deleteQuery);
            DB.CloseConnection();

            SavingsGoal goal = new SavingsGoal
            {
                StudentId = Session.LoggedStudent.Id,
                TargetAmount = amount,
                CreatedDate = DateTime.Now
            };
            bool success = repo.AddGoal(goal);
            if (success)
            {
                txtSavingsGoal.Text = amount.ToString("0.00") + " €";
                txtGoalAmount.Clear();
            }
            else
            {
                MessageBox.Show("Greška prilikom postavljanja cilja.");
            }
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            string amountText = txtLimitAmount.Text.Trim();

            if (string.IsNullOrEmpty(amountText) || cmbCategories.SelectedIndex == -1)
            {
                MessageBox.Show("Unesite iznos i odaberite kategoriju.");
                return;
            }
            if (!decimal.TryParse(amountText, out decimal amount))
            {
                MessageBox.Show("Unesite ispravan iznos.");
                return;
            }

            int studentId = Session.LoggedStudent.Id;
            int categoryId = (int)cmbCategories.SelectedValue;

            CategoryLimitRepository repo = new CategoryLimitRepository();

            var existingLimits = repo.GetLimitsByStudentId(studentId);
            CategoryLimit existingLimit = null;
            foreach (var l in existingLimits)
            {
                if (l.CategoryId == categoryId)
                {
                    existingLimit = l;
                    break;
                }
            }

            bool success;
            if (existingLimit != null)
            {
                existingLimit.LimitAmount = amount;
                success = repo.UpdateLimit(existingLimit);
            }
            else
            {
                CategoryLimit newLimit = new CategoryLimit
                {
                    StudentId = studentId,
                    CategoryId = categoryId,
                    LimitAmount = amount
                };
                success = repo.AddLimit(newLimit);
            }
            if (success)
            {
                txtLimitAmount.Clear();
                ShowLimits();
            }
            else
            {
                MessageBox.Show("Greška prilikom spremanja limita.");
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.LoggedStudent = null;
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            loginForm.ShowDialog();
            this.Close();
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
        private void lblExpense_MouseLeave(object sender, EventArgs e)
        {
            lblExpenses.Location = new Point(lblExpenses.Location.X + 5, lblExpenses.Location.Y);
            lblExpenses.Font = new Font(lblExpenses.Font.FontFamily, 11, FontStyle.Bold);
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
