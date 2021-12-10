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
    public partial class Read : Form
    {
        Database dbObj = new Database();
        public Read()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Create_Insert_Drop Cud= new Create_Insert_Drop();
            Cud.Show();
            this.Hide();
        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            if (LoginTxtBox.Text != string.Empty && PasswordTxtBox.Text != string.Empty)
            {
                string loginquery = $"select * from Student_Data where Student_Id='{LoginTxtBox.Text}' and Branch_Id='{PasswordTxtBox.Text}'";
                if (dbObj.SelectQuery(loginquery, PasswordTxtBox.Text))

                {
                    MessageBox.Show("Login successfully ");
                    Update upd = new Update();
                    upd.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" your account is not found please signup");
                }
                StaticVariable.Student_Name = LoginTxtBox.Text;
                StaticVariable.Branch_Id = PasswordTxtBox.Text;
            }
            else
            {
                MessageBox.Show("Please fill the required fields");
            }
        }
    }
}
