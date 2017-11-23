using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using ConfigurationHelper;

namespace DatabaseHelper
{
    public class Database
    {
        #region Private Members
        private SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataAdapter _da;
        private DataTable _dt;
        private string _connectionName;
        #endregion

        #region Public Properties
        public SqlCommand Command
        {
            get
            {
                return _cmd;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods

        #region Transactions

        public void BeginTransaction()
        {//GET THE CONNECTION STRING
            _cn.ConnectionString = Configuration.GetConnectionString(_connectionName);
          //TELL THE COMMAND ABOUT THE CONNECTION
            _cmd.Connection = _cn;
            //OPEN THE CONNECTION
            _cn.Open();
            //BEGIN TRANSACTION
            _cmd.Transaction=_cn.BeginTransaction();
        }

        public void EndTransaction()
        {
            _cmd.Transaction.Commit();
            _cn.Close();
        }

        public void RollBack()
        {
            _cmd.Transaction.Rollback();
            _cn.Close();
        }

        public SqlCommand ExecuteNonQueryIWithTransaction()
        {
           
            _cmd.ExecuteNonQuery();
            return _cmd;
        }
        #endregion

        #region NonTransactions
        public SqlCommand ExecuteNonQueryI()
        {
            _cn.ConnectionString = Configuration.GetConnectionString(_connectionName);
            _cn.Open();
            //TELL TEH COMMAND OBJECT ABOUT THE CONNECTION 
            _cmd.Connection = _cn;
            _cmd.ExecuteNonQuery();
            _cn.Close();
            return _cmd;
        }


        public DataTable ExectueQuery()
        {
            _cn.ConnectionString = Configuration.GetConnectionString(_connectionName);
            _cn.Open();
            //TELL TEH COMMAND OBJECT ABOUT THE CONNECTION 
            _cmd.Connection = _cn;
            //TELL THE DATA ADAPTER ABOUT THE COMMAND OBJECT
            _da = new SqlDataAdapter();
            _dt = new DataTable();
            _da.SelectCommand = _cmd;
            _da.Fill(_dt);


            _cn.Close();
            return _dt;
        }
        #endregion

        #endregion

        #region Event Handlers
        #endregion

        #region Construction
        public Database(string connectionName)
        {
            _connectionName = connectionName;
            _cn = new SqlConnection();
            _cmd = new SqlCommand();
        }
        #endregion
    }
}

