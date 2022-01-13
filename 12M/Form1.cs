using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        //StoredProcedure çalıştıktan sonra Stok sütununu doldurur
        public void FillStockColumns(DataTable dt)
        {
            int stok = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][2].ToString() == "Giriş")
                {
                    stok += Convert.ToInt32(dt.Rows[i][5]);
                }
                else if (dt.Rows[i][2].ToString() == "Çıkış")
                {
                    stok -= Convert.ToInt32(dt.Rows[i][6]);
                }

                SqlCommand addStock = new SqlCommand("update temptable set Stok=" + stok + "where SiraNo=" + dt.Rows[i][0] + "", dbCon.con);
                crud.Update(addStock);
            }
        }

        //StoredProcedure'ü çalıştırır
        public void RunStoredProcedure()
        {
            dbCon.con.Open();

            if (txtStart.Text == string.Empty || txtFinish.Text == string.Empty)
            {
                MessageBox.Show("Tarihler Boş");
            }
            else
            {

                //StoredProcedure çalışır ve tabloyu döndürür.
                DataTable dt = crud.StoredProcedure("stoklar", dbCon.con, txtProductCode.Text, txtStart.Text, txtFinish.Text);
                FillStockColumns(dt);

                //Tablonun Stok sütunu doldurulmuş halini ekrana basar.
                DataTable dataTable = crud.List("Select * from temptable", dbCon.con);
                dtResult.DataSource = dataTable;
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

            if (crud.errorMessage != string.Empty)
            {
                MessageBox.Show(crud.errorMessage);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
