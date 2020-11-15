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
    class HouseDAO
    {
        public static DataSet LoadDataCombobox()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "HOU");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet House_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("House_GetAll");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet House_Search(HouseDTO _House)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("House_Search", _House.ID, _House.RoomNumber, _House.FeeMonth, _House.IDHouseholder, _House.IDEmployee, _House.IDHouseType, _House.IDLocation);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet House_InsUpd(HouseDTO _House)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("House_InsUpd", _House.ID, _House.RoomNumber, _House.FeeMonth, _House.IDHouseholder, _House.IDEmployee, _House.IDHouseType, _House.IDLocation);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet House_Del(long _ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("House_Del", _ID);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }
    }
}
