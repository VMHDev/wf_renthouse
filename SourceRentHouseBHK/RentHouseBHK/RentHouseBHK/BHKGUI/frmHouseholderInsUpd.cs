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
    public partial class frmHouseholderInsUpd : Form
    {
        public static frmHouseholder frmParent { get; set; }
        
        #region Form
        public frmHouseholderInsUpd(frmHouseholder _Frm)
        {
            InitializeComponent();
            frmParent = _Frm;
            this.StartPosition = FormStartPosition.CenterParent;
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmHouseholderInsUpd_Load(object sender, EventArgs e)
        {
            LoadDataToForm();
        }
        #endregion

        #region Functions
        public void LoadDataToForm()
        {
        }
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                HouseholderDTO obj = new HouseholderDTO();
                obj.ID = -1;
                obj.Name = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;

                ds = HouseholderDAO.Householder_InsUpd(obj);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0]["Result"]) == 1)
                {
                    clsMessages.ShowInformation("Thêm thành công!");
                    frmParent.LoadDataToForm();
                    this.Close();
                }
                else
                {
                    clsMessages.ShowWarning("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
