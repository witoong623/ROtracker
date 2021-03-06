﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ROtracker
{
    class DBConnector
    {
        private MySqlConnection Connection;

        public DBConnector()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["rotracker"].ConnectionString;
            Connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
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
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        private void CloseConnection()
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

        public bool CanConnect()
        {
            if (OpenConnection())
            {
                CloseConnection();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
