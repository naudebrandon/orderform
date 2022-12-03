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
    public partial class Form3 : Form
    {
        String IPAddress;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnUpdateIPAddress_Click(object sender, EventArgs e)
        {
            //Update the entered IP Address in the Database
            try
            {

                DataClasses1DataContext DC = new DataClasses1DataContext();


  
                MessageBox.Show("IP Address Updated", "Update Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIpAddress.Clear();
                LoadPrinterIP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("IP Address not Updated", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadPrinterIP();
        }

        public void LoadPrinterIP()//Assign Current IP Address from database to IP Address textbox
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listBox1.Items.Add(printer);
            }
           
        }
    }
}
