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
                MessageBox.Show("Prihod dodan!");
                txtAmount.Clear();
                txtDescription.Clear();
                //ShowIncomes();
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
                Type = "Expense"
            };

            bool isAdded = repo.AddCategory(category, "Expense");

            if (isAdded)
            {
                MessageBox.Show("Kategorija dodana!");
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
    }
}
