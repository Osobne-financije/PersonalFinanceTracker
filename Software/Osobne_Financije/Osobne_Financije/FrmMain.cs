using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

    }
}
