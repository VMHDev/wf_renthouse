using RentHouseBHK.BHKBUS;
using RentHouseBHK.BHKDAO;
using RentHouseBHK.BHKUtilities.BHKMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouseBHK.BHKGUI
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
            txtUserName.ReadOnly = true;
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            txtUserName.Text = clsSystemProperties.UserLogin.UserName;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                string sUserName = txtUserName.Text.Trim();
                string sOldPass = clsEncryption.MD5Hash(txtOldPass.Text.Trim());
                string sNewPass = clsEncryption.MD5Hash(txtNewPass.Text.Trim());
                string sConfirmPass = clsEncryption.MD5Hash(txtConfirmPass.Text.Trim());
                if (sNewPass != sConfirmPass)
                {
                    clsMessages.ShowWarning("Mật khẩu nhập lại khác mật khẩu mới!");
                }
                ds = UsersDAO.Users_ChangePassword(sUserName, sOldPass, sNewPass);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Result"].Equals(1))
                {
                    clsMessages.ShowInformation("Đổi mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    clsMessages.ShowWarning(ds.Tables[0].Rows[0]["ErrorDesc"].ToString());
                }
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
    }
}
