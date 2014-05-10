using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace Persistance.Entities
{
    public class SPParameter
    {
        private readonly SqlParameter _parameter;

        public SqlParameter Parameter
        {
            get { return _parameter; }
        }

        public String Name
        {
            get { return _parameter.ParameterName; }
            set { _parameter.ParameterName = CheckName(value); }
        }

        public Object Value
        {
            get { return _parameter.Value; }
            set
            {
                if (value == null)
                    throw new Exception("Null value. Use DBNull.");

                _parameter.Value = value;
            }
        }

        public DbType DbType
        {
            get { return _parameter.DbType; }
            set { _parameter.DbType = value; }
        }

        public int Size
        {
            get { return _parameter.Size; }
            set { _parameter.Size = value; }
        }

        public bool IsNullable
        {
            get { return _parameter.IsNullable; }
            set { _parameter.IsNullable = value; }
        }

        public bool IsOutput
        {
            get { return _parameter.Direction == ParameterDirection.Output; }
            set { _parameter.Direction = ParameterDirection.Output; }
        }

        public bool IsInput
        {
            get { return _parameter.Direction == ParameterDirection.Input; }
            set { _parameter.Direction = ParameterDirection.Input; }
        }

        public bool IsInputOutput
        {
            get { return _parameter.Direction == ParameterDirection.InputOutput; }
            set { _parameter.Direction = ParameterDirection.InputOutput; }
        }

        public bool IsReturnValue
        {
            get { return _parameter.Direction == ParameterDirection.ReturnValue; }
            set { _parameter.Direction = ParameterDirection.ReturnValue; }
        }

        public ParameterDirection Direction
        {
            get { return _parameter.Direction; }
            set { _parameter.Direction = value; }
        }

        public SPParameter()
        {
            _parameter = new SqlParameter();
        }

        public SPParameter(String paramName, Object value)
        {
            paramName = CheckName(paramName);

            if (value == null)
                throw new Exception("Null value. Use DBNull.");

            _parameter = new SqlParameter(paramName, value);
        }

        private String CheckName(String name)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Null or Empty name.");

            if (name.Substring(1).Contains('@'))
                throw new Exception("Invalid name.");

            if (!name.Contains('@'))
                name = "@" + name;

            return name;
        }

        public SPParameter Nullable()
        {
            IsNullable = true;
            return this;
        }

        public SPParameter Output()
        {
            IsOutput = true;
            return this;
        }

        public SPParameter Input()
        {
            IsInput = true;
            return this;
        }

        public SPParameter InputOutput()
        {
            IsInputOutput = true;
            return this;
        }

        public SPParameter ReturnValue()
        {
            IsReturnValue = true;
            return this;
        }
    }
}
