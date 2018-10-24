using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source = GRAHAM-PC; Initial Catalog = cmpt395; Integrated Security = True";
            /*SqlConnection sqlCon = new SqlConnection(conStr);
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from Student", sqlCon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            foreach(DataRow row in dtbl.Rows)
            {
                Console.WriteLine(row["SID"]);
            }
            Console.ReadKey();*/

            SqlConnection sqlConnection1 = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spStudents";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
        }
    }
}