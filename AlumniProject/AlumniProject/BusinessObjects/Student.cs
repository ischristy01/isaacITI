using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;





namespace BusinessObjects
{
    public class Student : HeaderData
    {
        #region Private Members
        private string _Email;
        private string _Password;
        private string _FirstName;
        private string _LastName;
        private Guid _DepartmentId;
        private BrokenRuleList _BrokenRules;

        #endregion

        #region Public Properties


        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    base.IsDirty = true;
                }
            }

        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    base.IsDirty = true;
                }
            }

        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    base.IsDirty = true;
                }
            }
              
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    base.IsDirty = true;
                }
            }

        }

        public Guid DepartmentId
        {
            get
            {
                return _DepartmentId;
            }
            set
            {
                if (_DepartmentId!= value)
                {
                    _DepartmentId = value;
                    base.IsDirty = true;
                }
            }

        }


      

        #endregion

        #region Private Methods
        public Boolean Insert(Database database)
        {
            Boolean result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblStudentInsert";
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@DepartmentId", SqlDbType.UniqueIdentifier).Value = _DepartmentId;
                base.Initailize(database.Command, Guid.Empty);
                database.ExecuteNonQueryIWithTransaction();
                base.Initailize(database.Command);
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public Boolean Update(Database database)
        {
            Boolean result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblStudentUpdate";
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@DepartmentId", SqlDbType.UniqueIdentifier).Value = _DepartmentId;
                base.Initailize(database.Command, base.Id);
                database.ExecuteNonQueryIWithTransaction();
                base.Initailize(database.Command);
            }
            catch(Exception ex)    
            {
                result = false;
                throw;
            }
            return result;
        }


        public Boolean Delete(Database database)
        {
            Boolean result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblStudentDelete";
                base.Initailize(database.Command, base.Id);
                database.ExecuteNonQueryIWithTransaction();
                base.Initailize(database.Command);
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public Student GetById(Guid id)
        {
            Database database = new Database("Student");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
            dt = database.ExectueQuery();
            if (dt != null && dt.Rows.Count ==1)
            {
                DataRow dr = dt.Rows[0];
                base.Initailize(dr);
                InitalizeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
            }
            return this;
        }


        public Student Login(string Email, string Password)
        {
            Database database = new Database("Alumnus");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentLogIn";
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

            dt = database.ExectueQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                //GETS HEADER DATA
                base.Initailize(dr);
                //ADD CODE TO GET THE BUSINESS DATA
                InitalizeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
                return this;
            }
            else
            {
                return null;
            }
        }

        public bool Exists(string email)
        {
            bool result = false;
            Database database = new Database("Alumnus");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentEXISTS";
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;

            dt = database.ExectueQuery();
            if(dt != null && dt.Rows.Count == 1)
            {
                result = true;
            }
            return result;
        }

        public Student Register(string firstName, string lastName, string email, Guid DepartmentId)
        {
            // Generate a new 12-character password with one non alphanumeric character
            string password = Membership.GeneratePassword(12, 1);
            try
            {
                Database database = new Database("Student");
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblStudentInsert";
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@DepartmentId", SqlDbType.UniqueIdentifier).Value = _DepartmentId;

                _FirstName = firstName;
                _LastName = lastName;
                _Email = Email;
                _Password = Password;
                _DepartmentId = DepartmentId;
                base.IsDirty = true;
                base.IsNew = true;

                if(this.IsSavable() == true)
                {
                    base.Initailize(database.Command, Guid.Empty);
                    database.ExectueQuery();
                    base.Initailize(database.Command);
                    string address = _Email;
                    string subject = "Registration on the coolest siet";
                    string body = string.Format("Ypur password is: {0}. Please return to site and use this password");
                    //EmailHelper.Email.SendEmail(address, subject, body);
                }
                else
                {
                    throw new Exception("Invalid Register Data");
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return this;
        }
        
       
        #endregion

        private Boolean IsValid()
        {
            _BrokenRules.List.Clear();
            bool result = true;
            
            if (_FirstName == null || _FirstName == string.Empty)

            {
                result = false;
                BrokenRule rule = new BrokenRule("First NAme CANNOT be Empty");
                _BrokenRules.List.Add(rule);
            }
            if (_LastName == null || _LastName == string.Empty)

                {
                    result = false;
                BrokenRule rule = new BrokenRule("Last NAme CANNOT be Empty");
                _BrokenRules.List.Add(rule);
            }

            if (_Email == null || _Email == string.Empty)

            {
                result = false;
                BrokenRule rule = new BrokenRule("Email CANNOT be Empty");
                _BrokenRules.List.Add(rule);
            }


            if (_Password == null || _Password == string.Empty)

            {
                result = false;
                BrokenRule rule = new BrokenRule("Password CANNOT be Null");
                _BrokenRules.List.Add(rule);
            }

            if (_DepartmentId == null || _DepartmentId == Guid.Empty)

            {
                result = false;
                BrokenRule rule = new BrokenRule("Please select a department");
                _BrokenRules.List.Add(rule);
            }
            return result;
        }
        #region Public Methods
        public Boolean IsSavable()
        {
            Boolean result = false;
            //IF SOMETHING HAS CHANGED AND THE VALUES ARE VALID
            //NO EMPTY STRINGS FOR  FIRST NAME OR LAST NAME
            //if((base.IsDirty == true && IsValid()==true) || (_PersonEmails != null && _PersonEmails.IsSavable()== true || (_PersonPhones != null && _PersonPhones.IsSavable()==true)))
            if ((base.IsDirty == true && IsValid() == true))
                {
                result = true;
            }


            return result;
        }

        public Student Save()
        {
            Boolean result = true;
            //IF ENTRY IS NEW AND VAILD SUBIT NEW ENTRY TO DATABASE
            Database database = new Database("Alumnus");
            database.BeginTransaction();
            if(base.IsNew==true && IsSavable()== true)
            {
                result = Insert(database);
            }
            else if (base.Deleted == true && base.IsDirty==true)
            {
                result = Delete(database);
            }
            else if (base.IsNew == false && base.IsDirty==true && IsValid() ==true)
            {
                result = Update(database);
            }

            if(result == true)
            {
                base.IsDirty = false;
                base.IsNew = false;
            }
            //SAVE CHILD OBJECTS

            //COMMIT THE TRANSACTIONS OR ROLLBACK TRANSACTION
            if (result == true)
            {
                database.EndTransaction();
            }
            else
            {
                database.RollBack();
            }
            return this;
        }

       
        
        public void InitalizeBusinessData(DataRow dr)
        {
            _Email = dr["Email"].ToString();
            _Password = dr["Password"].ToString();
            _FirstName = dr["FirstName"].ToString();
            _LastName = dr["LastName"].ToString();
            _DepartmentId = (Guid)dr["DepartmentId"];
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Construction
        public Student()
        {
            _Email = string.Empty;
            _Password = string.Empty;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _DepartmentId = Guid.Empty;
            _BrokenRules = new BrokenRuleList();

        }
        #endregion
    }
}
