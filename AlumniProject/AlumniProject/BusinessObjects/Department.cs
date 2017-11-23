using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data;
using System.Web.Security;

namespace BusinessObjects
{
    public class Department : HeaderData
    {
        #region Private Members

        private string _Name = string.Empty;
        private BrokenRuleList _BrokenRules = new BrokenRuleList();

        #endregion

        #region Public Properties

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    base.IsDirty = true;
                    bool Saveable = IsSavable();
                
                }
            }
        }

        public BrokenRuleList BrokenRules
        {
            get { return _BrokenRules; }
        }
        #endregion

        #region  Private Methods 
        private bool Insert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = System.Data.CommandType.StoredProcedure;
                database.Command.CommandText = "tblDepartmentINSERT";
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;
                //PROVIDES THE EMPTY BUCKETS
                base.Initailize(database.Command, Guid.Empty);
                database.ExecuteNonQueryI();
                //UNLOADS THE FULL BUCKETS INTO THE OBJECT
                base.Initailize(database.Command);
            }
            catch (Exception e)
            {
                result = false;
                throw;
            }
            return result;

        }
        private bool Update(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = System.Data.CommandType.StoredProcedure;
                database.Command.CommandText = "tblDepartmentUPDATE";
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;
                base.Initailize(database.Command, base.Id);
                database.ExecuteNonQueryI();
                //UNLOADS THE FULL BUCKETS INTO THE OBJECT
                base.Initailize(database.Command);
            }
            catch (Exception e)
            {
                result = false;
                throw;
            }
            return result;


        }
        private bool Delete(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = System.Data.CommandType.StoredProcedure;
                database.Command.CommandText = "tblDepartmentDELETE";
                //PROVIDES THE EMPTY BUCKETS
                base.Initailize(database.Command, base.Id);
                database.ExecuteNonQueryI();
                //UNLOADS THE FULL BUCKETS INTO THE OBJECT
                base.Initailize(database.Command);
            }
            catch (Exception e)
            {
                result = false;
                throw;
            }
            return result;

        }

        private bool IsValid()
        {
            _BrokenRules.List.Clear();
            bool result = true;


            if (_Name == null || _Name.Trim() == string.Empty)
            {
                result = false;
                BrokenRule rule = new BrokenRule("Department Name cannot be empty.");
                _BrokenRules.List.Add(rule);
            }
            return result;

        }

        #endregion

        #region  Public Methods 
        public Department GetById(Guid id)
        {
            Database database = new Database("Alumnus");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblDepartmentGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
            dt = database.ExectueQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                base.Initailize(dr);
                InitializeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
            }
            return this;
        }

        public void InitializeBusinessData(DataRow dr)
        {
            _Name = dr["DepartmentName"].ToString();
        }

        public bool IsSavable()
        {
            bool result = false;
            if (base.IsDirty == true && IsValid() == true)
            {
                result = true;
            }
            return result;
        }

        public Department Save()
        {
            bool result = true;
            Database database = new Database("Student");

            if (base.IsNew == true && IsSavable() == true)
            {
                result = Insert(database);
            }
            else if (base.Deleted == true && base.IsDirty == true)
            {
                result = Delete(database);
            }
            else if (base.IsNew == false && IsValid() == true && IsDirty == true)
            {
                result = Update(database);
            }

            if (result == true)
            {
                base.IsDirty = false;
                base.IsNew = false;
            }
            return this;


        }
        #endregion

        #region  Public Events 

        #endregion

        #region  Public Event Handlers 

        #endregion

        #region Construction 
        public Department()
        {

        }
        #endregion
    }
}
