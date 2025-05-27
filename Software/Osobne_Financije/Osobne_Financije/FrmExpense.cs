using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Osobne_Financije
{
    public partial class FrmExpense: Form
    {
        public FrmExpense()
        {
            InitializeComponent();
        }

        private void FrmExpense_Load(object sender, EventArgs e)
        {
            CategoryRepository repo = new CategoryRepository();
            List<Category> Expensecategories = repo.GetCategoriesByType("Expense");

            cmbCategories.DataSource = Expensecategories;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "Id";

            ShowExpenses();
            ShowTotalExpense();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string amount = txtAmount.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(amount) || cmbCategories.SelectedIndex == -1 || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Unesite sve potrebne podatke");
                return;
            }
            if (!decimal.TryParse(amount, out decimal parsedAmount))
            {
                MessageBox.Show("Unesite ispravan iznos.");
                return;
            }
            int StudentId = Session.LoggedStudent.Id;

            Expense expense = new Expense
            {
                Amount = decimal.Parse(amount),
                CategoryId = (int)cmbCategories.SelectedValue,
                Description = description,
                Date = dtpDate.Value,
                StudentId = StudentId
            };

            ExpenseRepository repo = new ExpenseRepository();
            bool isAdded = repo.AddExpense(expense);

            if (isAdded)
            {
                txtAmount.Clear();
                txtDescription.Clear();
                ShowExpenses();
                ShowTotalExpense();
            }
            else
            {
                MessageBox.Show("Greška prilikom dodavanja troška.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Text.Trim();

            if (category == "")
            {
                MessageBox.Show("Unesite kategoriju");
                return;
            }

            CategoryRepository repo = new CategoryRepository();
            if (repo.CategoryExists(category))
            {
                MessageBox.Show("Kategorija već postoji!");
                return;
            }

            Category newCategory = new Category
            {
                Name = category,
                Type = "Expense"
            };

            bool isAdded = repo.AddCategory(category, "Expense");

            if (isAdded)
            {
                txtCategory.Clear();
                List<Category> updatedCategories = repo.GetCategoriesByType("Expense");
                cmbCategories.DataSource = null;
                cmbCategories.DataSource = updatedCategories;
                cmbCategories.DisplayMember = "Name";
                cmbCategories.ValueMember = "Id";

            }
            else
            {
                MessageBox.Show("Greška prilikom dodavanja kategorije.");
            }
        }
        private void ShowExpenses()
        { 
            ExpenseRepository expenseRepository = new ExpenseRepository();
            List<Expense> expense = expenseRepository.GetExpenseByStudentId(Session.LoggedStudent.Id);
            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = expense;

            dgvExpenses.Columns["CategoryName"].HeaderText = "Kategorija";
            dgvExpenses.Columns["CategoryName"].DisplayIndex = 0;
            dgvExpenses.Columns["Amount"].HeaderText = "Iznos";
            dgvExpenses.Columns["Amount"].DisplayIndex = 1;
            dgvExpenses.Columns["Description"].HeaderText = "Opis";
            dgvExpenses.Columns["Description"].DisplayIndex = 2;
            dgvExpenses.Columns["Date"].HeaderText = "Datum";
            dgvExpenses.Columns["Date"].DisplayIndex = 3;
            dgvExpenses.Columns["Id"].Visible = false;
            dgvExpenses.Columns["StudentId"].Visible = false;
            dgvExpenses.Columns["CategoryId"].Visible = false;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite trošak koji želite izbrisati");
                return;
            }
            var result = MessageBox.Show("Jeste li sigurni da želite izbrisati odabrani trošak?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int SelectedExpenseId = (int)dgvExpenses.SelectedRows[0].Cells["Id"].Value;

                ExpenseRepository repository = new ExpenseRepository();
                bool isDeleted = repository.DeleteExpense(SelectedExpenseId);

                if (isDeleted)
                {
                    ShowExpenses();
                }
                else
                {
                    MessageBox.Show("Greška prilikom brisanja troška");
                }
            }
        }

        private void ShowTotalExpense()
        {
            ExpenseRepository repository = new ExpenseRepository();
            decimal total = repository.GetTotalExpenseByStudentId(Session.LoggedStudent.Id);
            txtTotalExpense.Text = total.ToString("0.00");
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

        private void lblIncome_Click(object sender, EventArgs e)
        {
            FrmIncome frmIncome = new FrmIncome();
            frmIncome.Show();
            this.Hide();
        }
        private void lblIncome_MouseEnter(object sender, EventArgs e)
        {
            lblIncome.Location = new Point(lblIncome.Location.X - 5, lblIncome.Location.Y);
            lblIncome.Font = new Font(lblIncome.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblIncome_MouseLeave(object sender, EventArgs e)
        {
            lblIncome.Location = new Point(lblIncome.Location.X + 5, lblIncome.Location.Y);
            lblIncome.Font = new Font(lblIncome.Font.FontFamily, 11, FontStyle.Bold);
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
        private void lblSGoals_Click(object sender, EventArgs e)
        {
            FrmSavingsGoals savingsGoalsForm = new FrmSavingsGoals();
            savingsGoalsForm.Show();
            this.Hide();
        }
        private void lblSGoals_MouseEnter(object sender, EventArgs e)
        {
            lblSGoals.Location = new Point(lblSGoals.Location.X - 5, lblSGoals.Location.Y);
            lblSGoals.Font = new Font(lblSGoals.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblSGoals_MouseLeave(object sender, EventArgs e)
        {
            lblSGoals.Location = new Point(lblSGoals.Location.X + 5, lblSGoals.Location.Y);
            lblSGoals.Font = new Font(lblSGoals.Font.FontFamily, 11, FontStyle.Bold);
        }
    }
}
