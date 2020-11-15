using RentHouseBHK.BHKBUS;
using RentHouseBHK.BHKDTO;
using RentHouseBHK.BHKUtilities.BHKMessages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouseBHK.BHKDAO
{
    class UsersDAO
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="_UserName">Tên đăng nhập</param>
        /// <param name="_Password">Mật khẩu</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet Users_Login(string _UserName, string _Password)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Users_Login", _UserName, _Password);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        public static DataSet Users_ChangePassword(string _UserName, string _OldPass, string _NewPass)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsDatabaseExecute.ExecuteDatasetSP("Users_ChangePassword", _UserName, _OldPass, _NewPass);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
    }
}
