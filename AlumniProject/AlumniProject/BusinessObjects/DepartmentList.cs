using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class DepartmentList 
    {
        #region Private Members
        private BindingList<Department> _List;
        #endregion

        #region Public Properties
        public BindingList<Department> List
        {
            get
            {
                return _List;
            }
        }
        #endregion

        #region  Private Methods 

        #endregion

        #region  Public Methods 
        public DepartmentList GetAll()
        {
            Database database = new Database("Alumnus");
            database.Command.Parameters.Clear();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblDepartmentGetAll";
            DataTable dt = database.ExectueQuery();

            Department select = new Department();
            select.Id = Guid.Empty;
            select.Name = "--Please Select a Department--";
            _List.Add(select);

            foreach (DataRow dr in dt.Rows)
            {
                Department department = new Department();
                department.Initailize(dr);
                department.InitializeBusinessData(dr);
                department.IsNew = false;
                department.IsDirty = false;
                _List.Add(department);
            }
            return this;
        }

        public DepartmentList Save()
        {
            foreach (Department d in _List)
            {
                if (d.IsSavable() == true)
                {
                    d.Save();
                }
            }
            return this;
        }

        #endregion

        #region  Public Events 
       
        #endregion

          #region  Public Event Handlers 
       
        #endregion

        #region Construction 
        public DepartmentList()
        {
            _List = new BindingList<Department>();
           
        }
        #endregion
    }
}
