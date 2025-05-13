using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
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

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Text.Trim();

            if (category == "")
            {
                MessageBox.Show("Unesite kategoriju");
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
                cmbCategories.Items.Add(category);
            }
            else
            {
                MessageBox.Show("Greška prilikom dodavanja kategorije.");
            }
        }
    }
}
