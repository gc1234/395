using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CMPT395Project.Class
{
    public class DatabaseConnect
    {
        private static DatabaseConnect instance = new DatabaseConnect();
        private string serverstring= "";
        private SqlConnection con = null;
        public DatabaseConnect(){
           }

        public static DatabaseConnect Instance
        {
            get {
                return Instance;
                }
            }


        public SqlConnection Connect()
        {
            if (con == null)
            {
                con = new SqlConnection(serverstring);
                return con;
            }
            return con;
        }

        public string ConnectionString()
        {
            //var connection = @"Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";
            // Eriks connection string
            var connection = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";

            return connection;
        }









    }


  
    }

