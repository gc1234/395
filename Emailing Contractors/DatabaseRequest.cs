using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Utilities
{
    /// <summary>
    /// This class contains several methods that simplify database calls into one command line.
    /// It follows the Singleton design pattern to allow storing the SQLConnection instead of re-creating it every time.
    /// Before using the program, please ensure that the file "App.config" contains your login and password for the SQL Server database.
    /// 
    /// Authors: 
    ///     Brent Farand    BF
    /// 
    /// Changes:
    ///     2018-05-22  BF  Initial
    ///     2018-10-02  BF  Changed to a Singleton design pattern, initialized once once the program is started+
    ///                     Additional methods added to allow more options when settings commands and parameters
    ///     2018-10-29  BF  Added fields and methods required to allow database transactions
    ///     2018-11-01  BF  Added method to allow a file to be entered as a command parameter
    ///     2018-11-12  BF  Documentation improvements
    ///     2018-11-16  BF  Added 'AddCommandParameter' and 'ChangeCommandParameter' functions
    ///     
    /// References:
    ///     http://csharpindepth.com/Articles/General/Singleton.aspx
    ///     https://docs.microsoft.com/en-us/dotnet/api/system.transactions.transactionscope?view=netframework-4.7.2
    /// </summary>
    public sealed class DatabaseRequest
    {
        // The instance of DatabaseRequest - Singleton design pattern
        private static readonly Lazy<DatabaseRequest> instance = new Lazy<DatabaseRequest>(() => new DatabaseRequest());

        // The SQLConnection used to connect to the Database and send requests
        private readonly SqlConnection connection;

        // The current SQLCommand to be executed
        private SqlCommand cmd;

        private SqlTransaction transaction;

        private List<SqlCommand> transactionCmds;

        /// <summary>
        /// Returns the instance of DatabaseRequest - Singleton design pattern.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-10-02  BF  Initial
        /// </summary>
        /// 
        public static DatabaseRequest Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// Constructor for the instance of DatabaseRequest.
        /// Creates an SQLConnection and assigns it to 'connection'.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-10-02  BF  Initial
        /// </summary>
        private DatabaseRequest()
        {
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "put connecting string here",
                UserID = ConfigurationManager.AppSettings["dbUsername"].ToString(),
                Password = ConfigurationManager.AppSettings["dbPassword"].ToString(),
                InitialCatalog = "database name"
            };
            this.connection = new SqlConnection(connectionBuilder.ConnectionString);
            this.transactionCmds = new List<SqlCommand>();
        }

        /// <summary>
        /// Creates a new SqlCommand using a given query and sets it as the current command.
        /// Note that values of the query must be added using the SetCommandParameter method before executing the command.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-05-22  BF  Initial
        /// </summary>
        /// 
        /// <param name="query">A string containing the desired query for the SqlCommand to execute
        ///                     An example of valid query is:
        ///                     "SELECT ID FROM Employee WHERE(username = @username)"
        /// 
        /// </param>
        public static void SetCommand(string query)
        {
            Instance.cmd = new SqlCommand(query, Instance.connection);
        }

        /// <summary>
        /// Adds the given parameterName as a parameter of the Sqlcommand.
        /// No value is assigned to the parameterName value.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-16  BF  Initial
        /// </summary>
        /// <param name="parameterName"></param>
        public static void AddCommandParameter(string parameterName)
        {
            string valueParameterName = "@" + parameterName;
            Instance.cmd.Parameters.Add(new SqlParameter(valueParameterName, ""));
        }

        /// <summary>
        /// Adds the given parameterValue as the value to a parameter, parameterName, of the current command.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-05-22  BF  Initial
        /// </summary>
        /// 
        /// <param name="parameterName">A string containing the desired parameter of the command to set</param>
        /// <param name="parameterValue">A string containing the desired value of the parameter, parameterName</param>
        public static void SetCommandParameter(string parameterName, string parameterValue)
        {
            string valueParameterName = "@" + parameterName;
            Instance.cmd.Parameters.AddWithValue(valueParameterName, parameterValue);
        }

        /// <summary>
        /// Changes the given parameterName value to parameterValue
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-16  BF  Initial
        /// </summary>
        /// 
        /// <param name="parameterName">The desired parameter to change</param>
        /// <param name="parameterValue">The desired</param>
        public static void ChangeCommandParameter(string parameterName, string parameterValue)
        {
            string valueParameterName = "@" + parameterName;
            Instance.cmd.Parameters[valueParameterName].Value = parameterValue;
        }

        /// <summary>
        /// Version of SetCommandParameter that allows all parameters with matching values to be added in one function call.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-10-02  BF  Initial
        /// </summary>
        /// <param name="dict">A dictionary containing the following KeyValuePairs:
        ///                    Key - A string containing the desired parameter of the command to set
        ///                    Value - A string containing the desired value of the parameter, key
        /// </param>
        public static void SetCommandParameters(Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> entry in dict)
            {
                string valueParameterName = "@" + entry.Key;
                Instance.cmd.Parameters.AddWithValue(valueParameterName, entry.Value);
            }
        }

        /// <summary>
        /// Adds the given information of a file, fileBytes, as the value to a prameter, parameterName, of the current command.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-01  BF  Initial
        /// </summary>
        /// 
        /// <param name="parameterName">A string containing the desired parameter of the command to set</param>
        /// <param name="fileBytes">An array of bytes containing the information stored in a file</param>
        public static void SetCommandParameterFile(string parameterName, byte[] fileBytes)
        {
            Instance.cmd.Parameters.Add(parameterName, SqlDbType.VarBinary, fileBytes.Length).Value = fileBytes;
        }

        /// <summary>
        /// Adds the currently set command, 'cmd', to a transaction to be performed.
        /// The command being added to the transaction must be a NonQuery command, such as "UPDATE" or "INSERT".
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-10-29  BF  Initial
        /// </summary>
        public static void AddCurrentCommandToTransaction()
        {
            Instance.transactionCmds.Add(Instance.cmd);
        }

        /// <summary>
        /// Performs the transaction, executing all commands that were previously added.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-10-29  BF  Initial
        ///     2018-11-12  BF  Added transactionName parameter for greater reusability
        ///                     Changed MessageBox message to display a more readable error message to the user
        /// </summary>
        /// 
        /// <param name="transactionName">The name of the transaction, used for logging and error display purposes</param>
        public static bool PerformTransaction(string transactionName)
        {
            Instance.connection.Open();
            Instance.transaction = Instance.connection.BeginTransaction(transactionName);

            bool success = true;

            try
            {
                // Execute all commands in the transaction
                foreach (SqlCommand cmd in Instance.transactionCmds)
                {
                    cmd.Transaction = Instance.transaction;
                    cmd.ExecuteNonQuery();
                }
                Instance.transaction.Commit();
            }
            // At least one command in the transaction failed: rollback the transaction
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Transaction " + transactionName + " Failed: No changes have been made.");
                Instance.transaction.Rollback();
                success = false;
            }
            Instance.connection.Close();
            Instance.transactionCmds.Clear();

            return success;
        }

        /// <summary>
        /// Executes a previously set non-query SqlCommand.
        /// Examples of non-query commands include UPDATE, INSERT, and DELETE queries.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-05-22  BF  Initial
        /// </summary>
        /// 
        /// <returns> -1: If an error occured while executing the query
        ///           Otherwise, returns the number of rows affected
        /// </returns>
        public static int ExecuteNonQueryCommand()
        {
            Instance.connection.Open();
            int result = Convert.ToInt32(Instance.cmd.ExecuteNonQuery());
            Instance.connection.Close();
            return result;
        }

        /// <summary>
        /// Executes a previously set scalar-query SqlCommand.
        /// Examples of scalary-query commands include SELECT and COUNT.
        /// This is used if you want to check if at least one record is returned from your query.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-05-22  BF  Initial
        ///     2018-10-02  BF  Changed to return and accept generic types for greater reusability
        /// </summary>
        /// 
        /// <returns> null: If no results were returned
        ///           Otherwise, returns the first column of the first row in the result set
        /// </returns>
        public static T ExecuteScalarCommand<T>()
        {
            Instance.connection.Open();
            var result = Instance.cmd.ExecuteScalar();
            Instance.connection.Close();
            if (result is System.DBNull)
            {
                return default(T);
            }

            return (T)result;
        }

        /// <summary>
        /// Executes a previously set query SqlCommand and fills a DataTable with the returnws rows.
        /// Examples of reader-query commands include SELECT.
        /// This is used over ExecuteScalarCommand when you expect multiple rows to be returned and care about the data in each row.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-05-22  BF  Initial
        /// </summary>
        /// 
        /// <returns> records - A DataTable containing all rows returned from the execute query SqlCommand
        /// </returns>
        public static DataTable ExecuteReader()
        {
            DataTable records = new DataTable();
            Instance.connection.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(Instance.cmd))
            {
                adapter.Fill(records);
            }

            Instance.connection.Close();
            return records;
        }
    }
}