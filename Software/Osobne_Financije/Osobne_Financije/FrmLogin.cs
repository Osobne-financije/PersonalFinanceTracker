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
    public partial class FrmLogin: Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

 

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Unesite korisničko ime i lozinku.");
                return;
            }

            StudentRepository repo = new StudentRepository();
            Student student = repo.Login(username, password);

            if (student != null)
            {
                MessageBox.Show("Prijava uspješna!");
                this.Hide();
                new FrmMain().Show(); 
            }
            else
            {
                MessageBox.Show("Neispravno korisničko ime ili lozinka.");
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSignup signupForm = new FrmSignup();
            signupForm.Show();
        }
    }
}
