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
    class ContractDAO
    {
        public static DataSet LoadDataCombobox()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "BRA");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Contract_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Contract_GetAll");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Contract_Search(ContractDTO _Contract)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Contract_Search", _Contract.IDCustomer, _Contract.IDHouse, _Contract.IDEmployee, _Contract.ContractDate.ToString("dd/MM/yyyy"), "C");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Contract_InsUpd(ContractDTO _Contract)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Contract_InsUpd", _Contract.IDCustomer, _Contract.IDHouse, _Contract.IDEmployee, "C");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Contract_Del(ContractDTO _Contract)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Contract_Del", _Contract.IDCustomer, _Contract.IDHouse, _Contract.IDEmployee);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }
    }
}
