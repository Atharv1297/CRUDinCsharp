using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NcsCRUD
{
    public partial class Update : Form
    {
        Database dbObj = new Database();
        public Update()
        {
            InitializeComponent();
        }

        private void SubmitUpd_Click(object sender, EventArgs e)
        {
            if (Std_name.Text != string.Empty && Std_Id.Text != string.Empty && Std_Branch.Text != string.Empty && Branch_Id.Text != string.Empty)
            {
                string updatequery = $"UPDATE Student_Data SET Student_Name='{Std_name.Text}', Student_Id='{Std_Id.Text}', Branch='{Std_Branch.Text}', Branch_Id='{Branch_Id.Text}' where Student_Name='{StaticVariable.Student_Name}' and Branch_Id='{StaticVariable.Branch_Id}' ";
                if (dbObj.Ins_Up_Dro_Cre_Query(updatequery))

                {
                    MessageBox.Show("user details updated, try Login again");
                }
                else
                {
                    MessageBox.Show(" failed");

                }
            }
            else
            {
                MessageBox.Show("Please fil the required fields");
            }

        }

        private void try_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Read Read= new Read();
            Read.Show();
            this.Hide();
        }
    }
}
