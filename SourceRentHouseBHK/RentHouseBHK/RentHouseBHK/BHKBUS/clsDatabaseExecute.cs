using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKBUS
{
    class clsDatabaseExecute
    {
        public static DataSet ExecuteDatasetSP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteDataset(clsSystemProperties.objDatabase.Connection, _StoreName, _Params);
        }

        public static DataSet ExecuteDatasetSP(string _StoreName)
        {
            return SqlHelper.ExecuteDataset(clsSystemProperties.objDatabase.Connection, CommandType.Text, _StoreName);
        }

        public static int ExecuteNonQuerySP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteNonQuery(clsSystemProperties.objDatabase.Connection, _StoreName, _Params);
        }

        public static SqlDataReader ExecuteReaderSP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteReader(clsSystemProperties.objDatabase.Connection, _StoreName, _Params);
        }

        public static string ExecuteScalarSP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteScalar(clsSystemProperties.objDatabase.Connection, _StoreName, _Params).ToString();
        }

        public static DataSet LoadDataCombobox(params object[] _Params)
        {
            return SqlHelper.ExecuteDataset(clsSystemProperties.objDatabase.Connection, "LoadDataCombobox", _Params);
        }
    }
}
