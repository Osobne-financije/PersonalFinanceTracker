using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Osobne_Financije
{
    public partial class FrmIncome: Form
    {
        public FrmIncome()
        {
            InitializeComponent();
        }

        private void FrmIncome_Load(object sender, EventArgs e)
        {
            CategoryRepository repo = new CategoryRepository();
            List<Category> Incomecategories = repo.GetCategoriesByType("Income");

            cmbCategories.DataSource = Incomecategories;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "Id";

            ShowIncomes();
            ShowTotalIncome();
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

            Income income = new Income
            {
                Amount = decimal.Parse(amount),
                CategoryId = (int)cmbCategories.SelectedValue,
                Description = description,
                Date = dtpDate.Value,
                StudentId = StudentId
            };

            IncomeRepository repo = new IncomeRepository();
            bool isAdded = repo.AddIncome(income);

            if (isAdded)
            {
                MessageBox.Show("Prihod dodan!");
                txtAmount.Clear();
                txtDescription.Clear();
                ShowIncomes();
                ShowTotalIncome();
            }
            else
            {
                MessageBox.Show("Greška prilikom dodavanja prihoda.");
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
                Type = "Income"
            };

            bool isAdded = repo.AddCategory(category, "Income");

            if (isAdded)
            {
                MessageBox.Show("Kategorija dodana!");
                txtCategory.Clear();
                List<Category> updatedCategories = repo.GetCategoriesByType("Income");
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

        private void ShowIncomes()
        {
            IncomeRepository IncomeRepository = new IncomeRepository();
            List<Income> incomes = IncomeRepository.GetIncomesByStudentId(Session.LoggedStudent.Id);
            dgvIncomes.DataSource = null; 
            dgvIncomes.DataSource = incomes;

            dgvIncomes.Columns["CategoryName"].HeaderText = "Kategorija";
            dgvIncomes.Columns["CategoryName"].DisplayIndex = 0;
            dgvIncomes.Columns["Amount"].DisplayIndex = 1;
            dgvIncomes.Columns["Description"].DisplayIndex = 2;
            dgvIncomes.Columns["Date"].DisplayIndex = 3;
            dgvIncomes.Columns["Id"].Visible = false;
            dgvIncomes.Columns["StudentId"].Visible = false;
            dgvIncomes.Columns["CategoryId"].Visible = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvIncomes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite prihod koji želite izbrisati");
                return;
            }
            var result = MessageBox.Show("Jeste li sigurni da želite izbrisati odabrani prihod?","Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );

            if (result == DialogResult.Yes) 
            {
                int SelectedIncomeId = (int)dgvIncomes.SelectedRows[0].Cells["Id"].Value;

                IncomeRepository repository = new IncomeRepository();
                bool isDeleted = repository.DeleteIncome(SelectedIncomeId);

                if(isDeleted)
                {
                    MessageBox.Show("Prihod je uspješno izbrisan.");
                    ShowIncomes();
                }
                else
                {
                    MessageBox.Show("Greška prilikom brisanja prihoda");
                }
            }
        }

        private void ShowTotalIncome()
        {
            IncomeRepository repository = new IncomeRepository();
            decimal total = repository.GetTotalIncomeByStudentId(Session.LoggedStudent.Id);
            txtTotalIncome.Text = total.ToString("0.00");
        }

        private void btnLogut_Click(object sender, EventArgs e)
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

        private void lblExpense_Click(object sender, EventArgs e)
        {
            FrmExpense expenseForm = new FrmExpense();
            expenseForm.Show();
            this.Hide();
        }
        private void lblExpense_MouseEnter(object sender, EventArgs e)
        {
            lblExpense.Location = new Point(lblExpense.Location.X - 5, lblExpense.Location.Y);
            lblExpense.Font = new Font(lblExpense.Font.FontFamily, 13, FontStyle.Bold);
        }
        private void lblExpense_MouseLeave(object sender, EventArgs e)
        {
            lblExpense.Location = new Point(lblExpense.Location.X + 5, lblExpense.Location.Y);
            lblExpense.Font = new Font(lblExpense.Font.FontFamily, 11, FontStyle.Bold);
        }
    }
}
