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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Prijava uspješna!");
                // Open the main form or perform any other action
                this.Hide();
                FrmMain mainForm = new FrmMain();
                mainForm.Show();
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
