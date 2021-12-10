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
    public partial class Create_Insert_Drop : Form
    {
        Database dbObj = new Database();
        public Create_Insert_Drop()
        {
            InitializeComponent();
        }

        private void SubmitCUD_Click(object sender, EventArgs e)
        {
            
            if (Std_name.Text != string.Empty && Std_Id.Text != string.Empty && Std_Branch.Text != string.Empty && Branch_Id.Text != string.Empty)
            {
                string deletepquery = $"DROP TABLE IF EXISTS Student_Data";
                if(dbObj.Ins_Up_Dro_Cre_Query(deletepquery))
                {
                    MessageBox.Show("deleted");

                }

                string createpquery = $"CREATE TABLE Student_Data(id SERIAL, Student_Name VARCHAR(255), Student_Id INT, Branch VARCHAR(255), Branch_Id INT)";
                if (dbObj.Ins_Up_Dro_Cre_Query(createpquery))
                {
                    MessageBox.Show("created");

                }


                string insertpquery = $"INSERT INTO Student_Data(Student_Name,Student_Id,Branch,Branch_Id) VALUES ('{Std_name.Text}','{Std_Id.Text}','{Std_Branch.Text}','{Branch_Id.Text}')";

                if (dbObj.Ins_Up_Dro_Cre_Query(insertpquery))
                {
                    MessageBox.Show("user can log in now");

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
            Read Read = new Read();
            Read.Show();
            this.Hide();
        }
    }
}
