using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Bu sınıf temel CRUD işlemlerinin yapıldığı fonksiyonları barındırır
    public class CRUD
    {
        public string errorMessage = string.Empty;
        public void Save(IDbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
            }

        }

        public void Delete(IDbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }

        }

        public void Update(IDbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }



        }

        public DataTable List(string query, SqlConnection con)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);

            return dt;

        }
        public DataTable StoredProcedure(string procedureName, SqlConnection con, string MalKodu, string Start, string Finish)
        {
            //String olarak gelen tarihi Date tipine dönüştürür
            DateTime StartDate = Convert.ToDateTime(Start);
            DateTime FinishDate = Convert.ToDateTime(Finish);

            DataTable dt = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand(procedureName, con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("Malkodu", MalKodu);
                command.Parameters.AddWithValue("Baslangic", Convert.ToInt32(StartDate.ToOADate()));//Tarih tipini veritabanımızdaki değerin tipine dönüştürür
                command.Parameters.AddWithValue("Bitis", Convert.ToInt32(FinishDate.ToOADate()));

                SqlDataReader dr = command.ExecuteReader();
                dt.Load(dr);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }


            return dt;
        }

    }
}
