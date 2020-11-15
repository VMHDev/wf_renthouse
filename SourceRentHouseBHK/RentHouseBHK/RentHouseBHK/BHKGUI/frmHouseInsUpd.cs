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
    public partial class frmHouseInsUpd : Form
    {
        public static frmHouse frmParent { get; set; }
        #region Form
        public frmHouseInsUpd(frmHouse _Frm)
        {
            InitializeComponent();
            frmParent = _Frm;
            this.StartPosition = FormStartPosition.CenterParent;
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmHouseInsUpd_Load(object sender, EventArgs e)
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
                ds = LocationDAO.LoadDataCombobox();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboLocation.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboLocation.Items.Add(itemCbo);
                    }
                    cboLocation.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
                    dt.Clear();
                }
                ds.Clear();

                ds = EmployeeDAO.LoadDataCombobox().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboEmployee.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboEmployee.Items.Add(itemCbo);
                    }
                    cboEmployee.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
                    dt.Clear();
                }
                ds.Clear();

                ds = HouseholderDAO.LoadDataCombobox().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboHouseholder.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboHouseholder.Items.Add(itemCbo);
                    }
                    cboHouseholder.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
                    dt.Clear();
                }
                ds.Clear();

                ds = HouseTypeDAO.LoadDataCombobox().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboHouseType.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboHouseType.Items.Add(itemCbo);
                    }
                    cboHouseType.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
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
                HouseDTO obj = new HouseDTO();
                obj.ID = -1;
                obj.FeeMonth = string.IsNullOrWhiteSpace(txtFeeMonth.Text) ? -1 : Convert.ToInt32(txtFeeMonth.Text);
                obj.RoomNumber = string.IsNullOrWhiteSpace(txtRoomNumber.Text) ? -1 : Convert.ToInt32(txtRoomNumber.Text);
                obj.IDEmployee = Convert.ToInt64((cboEmployee.SelectedItem as clsComboItem).Value);
                obj.IDHouseholder = Convert.ToInt64((cboHouseholder.SelectedItem as clsComboItem).Value);
                obj.IDHouseType = Convert.ToInt64((cboHouseType.SelectedItem as clsComboItem).Value);
                obj.IDLocation = Convert.ToInt64((cboLocation.SelectedItem as clsComboItem).Value);

                ds = HouseDAO.House_InsUpd(obj);
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
