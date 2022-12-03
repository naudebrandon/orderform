using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;//For Printing to a Printer
using System.IO;
using System.Management;

namespace Order
{
    public partial class frmPlaceOrder : Form
    {
        int inumPostcard;
        int inumJumbo;
        int inum5X7;
        int inum6X8;
        int inum8X10;
        int inum8X12;
        int inumA3;
        int inumA2;
        int inumA1;

        string CName;
        string CNumber;
        string CEmail;
        string Assistant;
        string DoneBy;
        string hour;
        string minute;
        string time;
        //string OtherService;
        string OtherDetails;
        string Medium;//The 3 Services 
        string PaperSize;
        string Price;
        string DateOut;
        string Location;
        string Proof;
        string snumPostcard;
        string snumJumbo;
        string snum5X7;
        string snum6X8;
        string snum8X10;
        string snum8X12;
        string snumA3;
        string snumA2;
        string snumA1;
        
        String LocationRadGroup;
        String OrderDetailsRadGroupPaperType;
        String IP_Address;
        //String OrderDetailsRadGroupPaperCat;
        //String ProofingRadGroup;
        String Date;
        String Time;
        String CurrentDateTime;
        string PhoQ_S;

        //Array[] arrPhotoQty_Size=new Array[8];
        //PrintDocument pd;
        
        Boolean ProofCheck=true;
        Boolean PaperType;
        Boolean CustomerNameOK;
        Boolean CustomerNumberOK;
        Boolean CustomerEmailOK;
        Boolean LocationInput;
        Boolean AssistantOK;
        Boolean DoneByOK;
        Boolean NotesOK;
        Boolean TimeOK;
        //Boolean PaperType;
        //Boolean PaperCat;

        public frmPlaceOrder()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Input Validation
               
                CheckInputs();
                //RadButtonInput();
                if (!CustomerNameOK)
                {
                    MessageBox.Show("Please Enter Customer Name","Input Required",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                if (!CustomerNumberOK)
                {
                    MessageBox.Show("Please Enter Customer Phone Number", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!CustomerEmailOK)
                {
                    MessageBox.Show("Please Enter Email Address", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /*if (!LocationInput)
                {
                    MessageBox.Show("Please Select a location", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                if (!AssistantOK)
                {
                    MessageBox.Show("Please Enter Assistant Name", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!TimeOK)
                {
                    MessageBox.Show("Please enter correct time format", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /*if (!PaperType)
                {
                    MessageBox.Show("Please Select Other Service and Enter Other Service Description","No Service Selected",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }*/

                if (!DoneByOK)
                {
                    MessageBox.Show("Please enter the person's name to do the task", "No Task Assignment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!NotesOK)
                {
                    MessageBox.Show("Please enter some notes for futher instructions", "No Notes added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ProofCheck)
                {
                    return;
                }

            #endregion
            
                RadButtonInput();
                AssignValues();
                //LoadPrinterIP();
                //Printing Currently Disabled
                time = txtHour.Text + " " + ":" + " " + txtMinute;
                #region Print_Slip
                //String to Print
                    
                for (int i = 0; i < 2; i++)
                {
                    //-----------------------------------------------------------------------------------------------------------
                    string t = "FotoConnect";
                    string s = "Tel: 011 391 2117" + "    " + "Email: fotoconnect2@gmail.com" + "\n" + //--> 
                                "Cnr Mooirivier Rd James Wright Ave, Norkem Park" + "\n" + "\n" + 
                               "Date: " + CurrentDateTime + "\n" +
                               "Assistant: " + Assistant + "      " + "Done By: " + DoneBy + "\n" + "\n" +
                               "Name: " + CName + "\n" + 
                               "Number: " + CNumber + "\n" +
                               "Email: " + CEmail + "\n" + "\n" +
                               "Proof: " + Proof + "\n" +
                               "Service: " + Medium + "\n" + "\n" +
                               "Paper Type: " + OrderDetailsRadGroupPaperType + "\n" +
                               "Paper Sizes: " + "\n" + PhoQ_S + "\n" + "\n" +
                               "Notes: " + "\n" + OtherDetails + "\n" + "\n" +
                               "Customer Acceptance: " + " " + "\n" + "\n" + "___________________________________|" + "\n" + "\n" +
                               "Location: " + Location + "\n" + "\n" +
                               "Price: " + Price + "\n" +
                               "Date & Time Out: " + DateOut + "   " + time + "\n";
                    //-----------------------------------------------------------------------------------------------------------

                    PrintDocument p = new PrintDocument();
                    p.PrinterSettings.PrinterName = "Samsung SCX-4600 Series";
                    p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
                    {
                        e1.Graphics.DrawString(t, new Font("Arial", 15,FontStyle.Bold), new SolidBrush(Color.Black), new
                            RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                        e1.Graphics.DrawString(s, new Font("Arial", 8), new SolidBrush(Color.Black), new
                            RectangleF(0,40, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                    };
                    try
                    {
                        p.Print();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("An Error Occured While Printing -->", ex);
                       
                    }
                }

                #endregion

                Reset_Data_Fields();
                //SaveOrder();
                MessageBox.Show("Order Placed","Processed",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //Close();
        }

        private void CheckInputs()
        {
            Proofing();//Call Proofing Method

        #region Customer Details Input Validation
                    if (txtName.Text.Length < 1)
                    {
                        CustomerNameOK = false;
                    }
                    else
                    {
                        CustomerNameOK = true;
                    }

                    if (txtContactNumber.Text.Length >= 1 && txtContactNumber.Text.Length < 10)
                    {
                        MessageBox.Show("Please Enter A Valid Phone Number","Invalid Phone Number",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }

                    if (txtContactNumber.Text.Length < 1)
                    {
                        CustomerNumberOK = false;
                    }
                    else
                    {
                        CustomerNumberOK = true;
                    }
        #endregion

        #region Proofing Input Validation
                    if (ProofCheck)
                    {
                        if (txtEmail.Text.Length < 1)
                        {
                            CustomerEmailOK = false;
                        }
                        else
                        {
                            CustomerEmailOK = true;
                        }
                    }
                    else if (!ProofCheck)
                    {
                        CustomerEmailOK = true;
                    }
        #endregion

        //Not Required
        #region Location Input Validation 
           
                    /*if(rgbFax.Checked==false && rgbFrontE1.Checked==false && rgbGraphic1.Checked==false && rgbDGraphic2.Checked==false && rgbOther.Checked==false)
                    {
                        LocationInput = false;
                    }
                    else if (rgbFax.Checked == true || rgbFrontE1.Checked == true || rgbGraphic1.Checked == true || rgbDGraphic2.Checked == true || rgbOther.Checked == true)
                    {
                        LocationInput = true;
                    }*/
        #endregion

        #region Assistant Input Validation
                    if (txtAssistant.Text.Length < 1)
                    {
                        TimeOK = false;
                    }
                    else
                    {
                        TimeOK = true;
                    }
        #endregion

        #region Time Validation
        if (txtHour.Text.Length < 2 || txtMinute.Text.Length < 2)
        {
            AssistantOK = false;
        }
        else
        {
            AssistantOK = true;
        }
        #endregion

        #region Service Type Input Validation
                    if (rgbCanvas.Checked == false && rgbPhoto.Checked == false && rgbOtherService.Checked == false)
                    {
                        PaperType = false;
                        //MessageBox.Show("Please Select Other Service and Enter Other Service Description", "No Service Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (rgbOtherService.Checked == true)
                        {
                            if (txtOtherService.Text.Length < 1)
                            {
                                PaperType = false;
                                return;
                            }
                            else
                            {
                                PaperType = true;
                            }
                        }
                    }
            #endregion

        #region Done By Validation
            if (txtDoneBy.Text.Length < 1)
            {
                DoneByOK = false;
            }
            else
            {
                DoneByOK = true;
            }
        #endregion

        #region Notes Validation
                if (redOther.Text.Length < 1)
                {
                   NotesOK = false;
                }
                else
                {
                    NotesOK = true;
                }
            #endregion

        /*if (rgbCanvas.Checked == true)
        {
            PaperType = true;
        }*/

        if (rgbPhoto.Checked == true)
        {
            if (rgbMatt.Checked == false && rgbGloss.Checked == false)
            {
                MessageBox.Show("Please Select Matt or Gloss paper", "No Paper Type Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaperType = false;
                return;
            }
            else
            {
                PaperType = true;
                OrderDetailsRadGroupPaperType = " ";

            }
        }
       /*#region Paper Type

        #endregion

        #region Paper Cat

        #endregion*/

        }

        private void Proofing()
        {
            if (rgbProof.Checked == false && rgbPrint.Checked == false)
            {
                MessageBox.Show("Please Select Proofing Method","Proofing Method",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ProofCheck = false;
                return;
            }

            /*if (rgbProof.Checked==true)
            {
                ProofCheck = true;
            }
            if (rgbPrint.Checked == true)
            {
                ProofCheck = false;
            }*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
            
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar==008)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Please Enter A Valid Phone Number","Incorrect Format",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar==008 || e.KeyChar==046)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 044)
            {
                MessageBox.Show("',' is not valid--> use '.'","Invalid Format",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Price","Invalid Price Input",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void RadButtonInput()
        {
            //Assign Values to Radio Buttons
            #region Location Radio Button Group
                if (rgbFax.Checked==true)
                {
                    LocationRadGroup="Fax";
                }
                else if (rgbGraphic1.Checked == true)
                {
                    LocationRadGroup = "Graphic1";
                }
                else if (rgbDGraphic2.Checked == true)
                {
                    LocationRadGroup = "Graphic-d 2";
                }
                else if (rgbFrontE1.Checked == true)
                {
                    LocationRadGroup = "FrontE1";
                }
                else if (rgbOther.Checked == true)
                {
                    LocationRadGroup = "";
                }
            #endregion

            #region Proofing Radio Button Group
                if (rgbPrint.Checked == true)
                {
                    //ProofingRadGroup = "Print";
                    Proof="No";
                }
                else if (rgbProof.Checked == true)
                {
                    //ProofingRadGroup = "Proof";
                    Proof="Yes";
                }
   
            #endregion

            #region OrderDetails Radio Button Group [Paper Type]
                if (rgbGloss.Checked == true)
                {
                    OrderDetailsRadGroupPaperType = "Gloss";
                }
                if (rgbMatt.Checked == true)
                {
                    OrderDetailsRadGroupPaperType = "Matt";
                }
                if (rgbNone.Checked == true)
                {
                    OrderDetailsRadGroupPaperType = " ";
                }

            //-----------------------------------------------------
                if (rgbOtherService.Checked == true)
                {
                    Medium = txtOtherService.Text;
                }
                if (rgbCanvas.Checked == true)
                {
                    Medium = "Canvas";
                }
                if (rgbPhoto.Checked == true)
                {
                    Medium = "Photo Print";
                }
            #endregion

            #region OrderDetails Paper Size
                 //Not a required Value
                if (cb5X7.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUD5X7.Value.ToString() + " X - 5X7" + "\n";
                }

                if (cbPostcard.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUDPostcard.Value.ToString() + " X - Postcard" + "\n";
                }

                if (cbJumbo.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUDJumbo.Value.ToString() + " X - Jumbo(6X4)" + "\n";
                }

                if (cb6X8.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUD6X8.Value.ToString() + " X - 6X8" + "\n";
                }

                if (cb8X10.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUD8X10.Value.ToString() + " X - 8X10" + "\n";
                }

                if (cb8X12.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUD8X12.Value.ToString() + " X - 8X12" + "\n";
                }

                if (cbA3.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUDA3.Value.ToString() + " X - A3" + "\n";
                }

                if (cbA2.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUDA2.Value.ToString() + " X - A2" + "\n";
                }

                if (cbA1.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUDA1.Value.ToString() + " X - A1" + "\n";
                }

                if (cbA0.Checked == true)
                {
                    PhoQ_S = PhoQ_S + numUDA0.Value.ToString() + " X - A0" + "\n";
                }
                /*if (clbSize.SelectedItem.ToString() == "")
                {
                    PaperSize = "Non Photo Print";
                }
                else
                {
                    PaperSize = clbSize.SelectedItem.ToString();
                }*/
      
                /*if (clbSize.SelectedItem == "Postcard")
                {
                    PaperSize = "Postcard";
                }

                if (clbSize.SelectedItem == "Jumbo")
                {
                    PaperSize = "Jumbo";
                }

                if (clbSize.SelectedItem == "5X7")
                {
                    PaperSize = "5X7";
                }

                if (clbSize.SelectedItem == "6X8")
                {
                    PaperSize = "6X8";
                }

                if (clbSize.SelectedItem == "8X10")
                {
                    PaperSize = "8X10";
                }

                if (clbSize.SelectedItem == "8X12")
                {
                    PaperSize = "8X12";
                }

                if (clbSize.SelectedItem == "A3")
                {
                    PaperSize = "A3";
                }

                if (clbSize.SelectedItem == "A2")
                {
                    PaperSize = "A2";
                }

                if (clbSize.SelectedItem == "A1")
                {
                    PaperSize = "A1";
                }*/
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset_Data_Fields();

            //Date = DateTime.Now.ToLongDateString();
            #region Test Data
            /*txtAssistant.Text = "Tania";
            txtName.Text = "Daniel";
            txtContactNumber.Text = "0789875412";
            txtEmail.Text = "danielp@hotmail.com";
            rgbProof.Checked = true;
            rgbGraphic1.Checked = true;
            txtFilePath.Text="00clients- " + txtName.Text + " " + txtContactNumber.Text;
            //txtFilePath.Text="00Clients/2015 January/ " + Date.ToString();
            txtPrice.Text = "35.50";
            cb5X7.Checked = true;
            cb8X12.Checked = true;
            cbA2.Checked = true;
            numUD5X7.Value = 3;
            numUD8X12.Value = 2;
            numUDA2.Value = 1;
            rgbGloss.Checked = true;
            rgbPhoto.Checked = true;
            txtDoneBy.Text = "Klara";
            redOther.Text = "Please print all the photos in Black & White whith a black border all around.  Laminate the A1 Photograph, and Frame the 8X12 Photographs.";*/
            #endregion
        }

        private void SaveOrder()
        {
            StreamWriter SW;

            try
            {
                string FileName = (CName + CNumber + CurrentDateTime).ToString();
                SW=new StreamWriter(File.Open(@"G:\Orders\"+FileName+".txt",FileMode.Create));
                try
                {
                    SW.WriteLine(CurrentDateTime);
                    SW.WriteLine(Assistant);
                    SW.WriteLine(DoneBy);
                    SW.WriteLine(CName);
                    SW.WriteLine(CNumber);
                    SW.WriteLine(CEmail);
                    SW.WriteLine(Proof);
                    SW.WriteLine(Medium);
                    SW.WriteLine(OrderDetailsRadGroupPaperType);
                    SW.Write(PhoQ_S);
                    SW.WriteLine(OtherDetails);
                    SW.WriteLine(Location);
                    SW.WriteLine(Price);
                    SW.WriteLine(DateOut);

                    SW.Flush();
                }
               finally
                {
                    SW.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not write to file" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AssignValues()
        {
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
            CurrentDateTime = Date + " " + Time;//Add the Date and the Time Together in one string.

            CName = txtName.Text;
            CNumber = txtContactNumber.Text;
            CEmail = txtEmail.Text;
            Assistant = txtAssistant.Text;
            OtherDetails = redOther.Text;
            Price ="R " + txtPrice.Text;
            DateOut = dateTimePicker.Value.ToShortDateString();
            Location = (LocationRadGroup + "-" + txtFilePath.Text);
            DoneBy = txtDoneBy.Text;

            /*snum5X7 = numUD5X7.Value.ToString();
            snum6X8 = numUD6X8.Value.ToString();
            snum8X10 = numUD8X10.Value.ToString();
            snum8X12 = numUD8X12.Value.ToString();
            snumA1 = numUDA1.Value.ToString();
            snumA2 = numUDA2.Value.ToString();
            snumA3 = numUDA3.Value.ToString();
            snumJumbo = numUDJumbo.Value.ToString();
            snumPostcard =  numUDPostcard.Value.ToString();*/
        }

        private void Reset_Data_Fields()
        {
            txtName.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
            txtAssistant.Clear();
            txtFilePath.Clear();
            txtPrice.Clear();
            txtDoneBy.Clear();
            redOther.Clear();
            txtOtherService.Clear();
            txtHour.Clear();
            txtMinute.Clear();

            PhoQ_S = " ";

            numUD5X7.Value = 0;
           numUD6X8.Value= 0;
           numUD8X10.Value= 0;
           numUD8X12.Value= 0;
           numUDA1.Value= 0;
           numUDA2.Value= 0;
           numUDA3.Value= 0;
           numUDJumbo.Value= 0;
           numUDPostcard.Value= 0;

            cbPostcard.Checked = false;
            cbJumbo.Checked = false;
            cb5X7.Checked = false;
            cb6X8.Checked = false;
            cb8X10.Checked = false;
            cb8X12.Checked = false;
            cbA3.Checked = false;
            cbA2.Checked = false;
            cbA1.Checked = false;

            rgbPhoto.Checked = false;
            rgbCanvas.Checked = false;
            rgbOtherService.Checked = false;

            rgbGloss.Checked = false;
            rgbMatt.Checked = false;

            rgbPrint.Checked = false;
            rgbProof.Checked = false;

            rgbFax.Checked = false;
            rgbGraphic1.Checked = false;
            rgbFrontE1.Checked = false;
            rgbDGraphic2.Checked = false;
            rgbOther.Checked = false;

            dateTimePicker.Value = DateTime.Now;//Minimum date is set to today
            dateTimePicker.MinDate = DateTime.Now;
        }

        public void LoadPrinterIP()//Assign Current IP Address from database to IP Address textbox
        {
            DataClasses1DataContext DC = new DataClasses1DataContext();

            try
            {
                var IPAddress = (from c in DC.GetTable<tblPrinterIP>()
                                 where c.IPID == "1"
                                 select c).SingleOrDefault();

                IP_Address = IPAddress.IP_Address;
            }
            catch (Exception ex)
            {
                MessageBox.Show("IP Address cannot be loaded", "IP Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 008)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Please Enter numerical values only", "Incorrect Format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 008)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Please Enter numerical values only", "Incorrect Format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
