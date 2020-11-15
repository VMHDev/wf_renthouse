using RentHouseBHK.BHKBUS;
using RentHouseBHK.BHKDTO;
using RentHouseBHK.BHKUtilities.BHKMessages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKDAO
{
    class EmployeeDAO
    {
        public static DataSet LoadDataCombobox()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "EMP");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Employee_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Employee_GetAll");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Employee_Search(EmployeeDTO _Employee)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Employee_Search", _Employee.ID, _Employee.Name, _Employee.Address, _Employee.Phone, _Employee.Gender, _Employee.Birthday.ToString("dd/MM/yyyy"), _Employee.Salary, _Employee.IDBranchOffice);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Employee_InsUpd(EmployeeDTO _Employee)
        {
            DataSet ds = new DataSet();
            try
            {
                string sPassword = clsEncryption.MD5Hash("1");
                ds = clsDatabaseExecute.ExecuteDatasetSP("Employee_InsUpd", _Employee.ID, _Employee.Name, _Employee.Address, _Employee.Phone, _Employee.Gender, _Employee.Birthday, _Employee.Salary, _Employee.IDBranchOffice, sPassword);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Employee_Del(long _ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Employee_Del", _ID);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }
    }
}
