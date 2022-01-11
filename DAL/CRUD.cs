using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CRUD
    {
        public void Save(IDbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
            }



        }
      

        public DataTable List(string procedureName, SqlConnection con,string MalKodu,string Start,string Finish)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand(procedureName, con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("Malkodu", MalKodu);
                command.Parameters.AddWithValue("Baslangic", Start);
                command.Parameters.AddWithValue("Bitis", Finish);

                SqlDataReader dr = command.ExecuteReader();

              
                if (dr.Read())
                {
                    foreach(var item in dr)
                    {
                        dt.Rows.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return dt;
        }

    }
}
