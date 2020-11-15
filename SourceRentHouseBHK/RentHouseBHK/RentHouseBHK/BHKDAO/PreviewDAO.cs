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
    class PreviewDAO
    {
        public static DataSet Preview_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Preview_GetAll");
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Preview_Search(PreviewDTO _Preview)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Preview_Search", _Preview.IDCustomer, _Preview.IDHouse, _Preview.PreviewDate.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Preview_InsUpd(PreviewDTO _Preview)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Preview_InsUpd", _Preview.IDCustomer, _Preview.IDHouse, _Preview.Comment);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }

        public static DataSet Preview_Del(PreviewDTO _Preview)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Preview_Del", _Preview.IDCustomer, _Preview.IDHouse, _Preview.PreviewDate.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            return ds;
        }
    }
}
