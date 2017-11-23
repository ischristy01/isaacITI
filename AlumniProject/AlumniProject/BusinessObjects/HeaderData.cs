using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace BusinessObjects
{
    public class HeaderData
    {
        #region Private Members
        private Guid _Id;
        private int _Version;
        private DateTime _LastUpdated;
        private Boolean _Deleted;
        private Boolean _IsNew = true;
        private Boolean _IsDirty = false;
        #endregion

        #region Public Properties
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public int Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return _LastUpdated;
            }
            set
            {
                _LastUpdated = value;
            }
        }

        public Boolean Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                _Deleted = value;
                _IsDirty = true;
            }
        }

        public Boolean IsNew
            //IS NEW = TRUE = INSERT 
            //IS NEW = FALSE = UPDATE
        {
            get
            {
                return _IsNew;
            }
            set
            {
                _IsNew = value;
            }
        }

        public Boolean IsDirty
            //DATA HAS BEEN ALTERED 
        {
            get
            {
                return _IsDirty;
            }
            set
            {
                _IsDirty = value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Initailize(SqlCommand cmd, Guid Id)
        {
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = "@Id";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.UniqueIdentifier;
            parm.Value = Id;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@Version";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.Int;
            parm.Value = 0;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@LastUpdated";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.DateTime;
            parm.Value = DateTime.MaxValue;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@Deleted";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.Bit;
            parm.Value = 0;
            cmd.Parameters.Add(parm);

        }

        public void Initailize(SqlCommand cmd)
        {
            _Id = (Guid) cmd.Parameters["@Id"].Value;
            _Version = (int) cmd.Parameters["@Version"].Value;
            _LastUpdated = (DateTime)cmd.Parameters["@LastUpdated"].Value;
            _Deleted = (Boolean) cmd.Parameters["@Deleted"].Value;


        }

        public void Initailize(DataRow dr)
        {
            _Id = (Guid)dr["Id"];
            _Version = (int)dr["Version"];
            _LastUpdated = (DateTime)dr["LastUpdated"];
            _Deleted = (Boolean)dr["Deleted"];
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Construction
        #endregion
    }
}
