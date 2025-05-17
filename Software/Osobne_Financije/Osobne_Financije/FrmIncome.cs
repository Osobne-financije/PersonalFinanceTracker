using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Collections.Generic;
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
    }
}
