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
    class HouseTypeDAO
    {
        public static DataSet LoadDataCombobox()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "HOT");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet HouseType_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("HouseType_GetAll");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet HouseType_Search(HouseTypeDTO _HouseType)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("HouseType_Search", _HouseType.ID, _HouseType.Name, _HouseType.Description);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet HouseType_InsUpd(HouseTypeDTO _HouseType)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("HouseType_InsUpd", _HouseType.ID, _HouseType.Name, _HouseType.Description);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet HouseType_Del(long _ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("HouseType_Del", _ID);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }
    }
}
