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
    public partial class frmCustomerInsUpd : Form
    {
        public static frmCustomer frmParent { get; set; }
        #region Form
        public frmCustomerInsUpd(frmCustomer _Frm)
        {
            InitializeComponent();
            frmParent = _Frm;
            this.StartPosition = FormStartPosition.CenterParent;
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmCustomerInsUpd_Load(object sender, EventArgs e)
        {
            LoadDataToCombobox();
        }
        #endregion

        #region Functions
        private void LoadDataToCombobox()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = BranchOfficeDAO.LoadDataCombobox().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboBranchOffice.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboBranchOffice.Items.Add(itemCbo);
                    }
                    cboBranchOffice.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
                    dt.Clear();
                }
                ds.Clear();
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
                dt.Dispose();
            }
        }
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                CustomerDTO obj = new CustomerDTO();
                obj.ID = -1;
                obj.Name = txtName.Text;
                obj.Phone = txtPhone.Text;
                obj.Address = txtAddress.Text;
                obj.Description = txtDescription.Text;
                obj.AbilityRent = chkAbilityRent.Checked;
                obj.IDBranchOffice = Convert.ToInt64((cboBranchOffice.SelectedItem as clsComboItem).Value);

                ds = CustomerDAO.Customer_InsUpd(obj);
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
