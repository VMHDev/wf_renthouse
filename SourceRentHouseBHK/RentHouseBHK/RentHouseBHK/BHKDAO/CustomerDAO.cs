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
    class CustomerDAO
    {
        public static DataSet LoadDataCombobox()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "CUS");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Customer_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Customer_GetAll");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Customer_Search(CustomerDTO _Customer)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Customer_Search", _Customer.ID, _Customer.Name, _Customer.Phone, _Customer.Address, _Customer.Description, _Customer.AbilityRent, _Customer.IDBranchOffice);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Customer_InsUpd(CustomerDTO _Customer)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Customer_InsUpd", _Customer.ID, _Customer.Name, _Customer.Phone, _Customer.Address, _Customer.Description, _Customer.AbilityRent, _Customer.IDBranchOffice);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Customer_Del(long _ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Customer_Del", _ID);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }
    
    }
}
