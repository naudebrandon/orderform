using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections;

namespace Order
{
    public partial class frmLogin : Form
    {
        String Username,Users;
        String Password,Pass;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Users = cobUsername.Text;
            Pass = txtAccessCode.Text;
            DataClasses1DataContext DC = new DataClasses1DataContext();

            var User = (from c in DC.GetTable<tblUser>()
                        where c.Username == Users
                        select c).SingleOrDefault();

            Username = User.Username;
            Password = User.Password;
            
            if ((Username == "Operator 1" || Username=="Operator 2") && Pass == Password)//Operator Login
            {
                txtAccessCode.Clear();
                MessageBox.Show("Welcome Operator","Login Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmPlaceOrder fmOrder = new frmPlaceOrder();
                fmOrder.Show();
                return;
                
            }
            else if (Username == "Admin" && Pass == Password) //Administrator Login
            {
                txtAccessCode.Clear();
                MessageBox.Show("Welcome Administrator", "Login Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 frmAdmin = new Form3();
                frmAdmin.Show();
                return;
            }
            else
            {
                MessageBox.Show("Please verify your Username and Password", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
