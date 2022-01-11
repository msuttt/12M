using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace _12M
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConnectionAdress dbCon = new ConnectionAdress();
        CRUD crud = new CRUD();

        public void RunStoredProcedure()
        {
            dbCon.con.Open();

            if (txtProductCode.Text == string.Empty && txtStart.Text == string.Empty && txtFinish.Text == string.Empty)
            {
                MessageBox.Show("Bazı alanlar boş");
            }
            else
            {
                DataTable dt = crud.List("", dbCon.con, txtProductCode.Text, txtStart.Text, txtFinish.Text);
                dtResult.DataSource = dt;
            }


            dbCon.con.Close();
        }

        public void ClearTextBoxes()
        {
            txtProductCode.Text = string.Empty;
            txtStart.Text = string.Empty;
            txtFinish.Text = string.Empty;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

            RunStoredProcedure();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
