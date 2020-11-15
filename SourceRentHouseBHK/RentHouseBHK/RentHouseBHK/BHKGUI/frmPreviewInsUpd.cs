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
    public partial class frmPreviewInsUpd : Form
    {
        public static frmPreview frmParent { get; set; }

        public frmPreviewInsUpd(frmPreview _Frm)
        {
            InitializeComponent();
            frmParent = _Frm;
            dtpPreviewDate.Value = DateTime.Now;
            this.StartPosition = FormStartPosition.CenterParent;
            LoadDataToCombobox();
        }

        public void LoadDataToCombobox()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = CustomerDAO.LoadDataCombobox().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboCustomer.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboCustomer.Items.Add(itemCbo);
                    }
                    cboCustomer.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
                    dt.Clear();
                }
                ds.Clear();

                ds = HouseDAO.LoadDataCombobox().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    cboHouse.Items.Add(new clsComboItem(-1, ""));
                    foreach (DataRow item in dt.Rows)
                    {
                        clsComboItem itemCbo = new clsComboItem();
                        itemCbo.Value = item["Value"];
                        itemCbo.Display = item["Display"].ToString();
                        cboHouse.Items.Add(itemCbo);
                    }
                    cboHouse.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
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

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                PreviewDTO obj = new PreviewDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.PreviewDate = dtpPreviewDate.Value.Date;
                obj.Comment = txtComment.Text;

                ds = PreviewDAO.Preview_InsUpd(obj);
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
