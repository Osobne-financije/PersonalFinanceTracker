using Osobne_Financije.Models;
using Osobne_Financije.Repositories;
using System;
using System.Windows.Forms;

namespace Osobne_Financije
{
    public partial class FrmSignup : Form
    {
        public FrmSignup()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFName.Text.Trim();
            string lastName = txtLName.Text.Trim();
            string username = txtUName.Text.Trim();
            string password = txtPass.Text;
            string confirmPassword = txtCPass.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Molimo ispunite sva polja.");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Lozinke se ne podudaraju.");
                return;
            }

            Student novi = new Student
            {
                Firstname = firstName,
                Lastname = lastName,
                Username = username,
                Password = password
            };

            StudentRepository studentRepository = new StudentRepository();
            bool isRegistered = studentRepository.Signup(novi);

            if (isRegistered)
            {
                MessageBox.Show("Registracija uspješna!");
                this.Hide();
                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Registracija nije uspjela. Pokušajte ponovo.");
            }
        }
    }
}
