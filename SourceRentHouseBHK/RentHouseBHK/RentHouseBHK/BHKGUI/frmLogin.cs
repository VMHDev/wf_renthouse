using RentHouseBHK.BHKBUS;
using RentHouseBHK.BHKDAO;
using RentHouseBHK.BHKDTO;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                string sUserName = txtUserName.Text.Trim();
                string sPassword = clsEncryption.MD5Hash(txtPassword.Text.Trim());
                ds = UsersDAO.Users_Login(sUserName, sPassword);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Result"].Equals(1))
                {
                    string sUserLogin = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                    bool bIsAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["Result"]);
                    clsSystemProperties.UserLogin = new UsersDTO(sUserLogin, bIsAdmin);

                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    clsMessages.ShowError("Đăng nhập thất bại!");
                }
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
    }
}
