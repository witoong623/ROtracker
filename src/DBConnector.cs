using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FileManage;

namespace ROtracker.src
{
    class DBConnector
    {
        private MySqlConnection Connection;

        public DBConnector()
        {
            var buid = new clsBuildConnectionString("sql.txt");

            if (buid.BuildConnectionString())
            {
                Connection = new MySqlConnection(buid.ConnectionString);
            }
            else
            {
                return;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    Connection.Open();
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot open connection because cannot build connection string",
                    "Cannot build connection string", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
