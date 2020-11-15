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
    public partial class frmBranchOffice : Form
    {
        #region Form
        public frmBranchOffice()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmBranchOffice_Load(object sender, EventArgs e)
        {
            InitColumnGridView();
            LoadDataToForm();
            LoadDataToCombobox();
        }
        #endregion

        #region Functions
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
            BringToFront();
        }

        private void InitColumnGridView()
        {
            #region ID Chi nhánh
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Chi nhánh";
            colID.Name = "colBranchOfficeID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvBranchOffice.Columns.Add(colID);
            #endregion

            #region Tên Chi nhánh
            DataGridViewColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Tên Chi nhánh";
            colName.Name = "colBranchOfficeName";
            colName.ReadOnly = true;
            colName.Visible = true;
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleName = new DataGridViewCellStyle();
            dgvCellStyleName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleName.Font = new Font("Arial", 12F);
            colName.DefaultCellStyle = dgvCellStyleName;
            dgvBranchOffice.Columns.Add(colName);
            #endregion

            #region Số điện thoại
            DataGridViewColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "Số điện thoại";
            colPhone.Name = "colBranchOfficePhone";
            colPhone.ReadOnly = true;
            colPhone.Visible = true;
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStylePhone = new DataGridViewCellStyle();
            dgvCellStylePhone.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStylePhone.Font = new Font("Arial", 12F);
            colPhone.DefaultCellStyle = dgvCellStylePhone;
            dgvBranchOffice.Columns.Add(colPhone);
            #endregion

            #region Số Fax
            DataGridViewColumn colFax = new DataGridViewTextBoxColumn();
            colFax.DataPropertyName = "Fax";
            colFax.HeaderText = "Số Fax";
            colFax.Name = "colBranchOfficeFax";
            colFax.ReadOnly = true;
            colFax.Visible = true;
            colFax.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleFax = new DataGridViewCellStyle();
            dgvCellStyleFax.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleFax.Font = new Font("Arial", 12F);
            colFax.DefaultCellStyle = dgvCellStyleFax;
            dgvBranchOffice.Columns.Add(colFax);
            #endregion

            #region ID Địa chỉ
            DataGridViewColumn colIDLocation = new DataGridViewTextBoxColumn();
            colIDLocation.DataPropertyName = "IDLocation";
            colIDLocation.HeaderText = "ID Địa chỉ";
            colIDLocation.Name = "colIDLocation";
            colIDLocation.ReadOnly = true;
            colIDLocation.Visible = false;
            dgvBranchOffice.Columns.Add(colIDLocation);
            #endregion

            #region Địa chỉ
            DataGridViewColumn colAddress = new DataGridViewTextBoxColumn();
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Địa chỉ";
            colAddress.Name = "colBranchOfficeAddress";
            colAddress.ReadOnly = true;
            colAddress.Visible = true;
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleAddress = new DataGridViewCellStyle();
            dgvCellStyleAddress.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleAddress.Font = new Font("Arial", 12F);
            colAddress.DefaultCellStyle = dgvCellStyleAddress;
            dgvBranchOffice.Columns.Add(colAddress);
            #endregion

            #region Khu vực
            DataGridViewColumn colRegion = new DataGridViewTextBoxColumn();
            colRegion.DataPropertyName = "Region";
            colRegion.HeaderText = "Khu vực";
            colRegion.Name = "colBranchOfficeRegion";
            colRegion.ReadOnly = true;
            colRegion.Visible = true;
            colRegion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleRegion = new DataGridViewCellStyle();
            dgvCellStyleRegion.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleRegion.Font = new Font("Arial", 12F);
            colRegion.DefaultCellStyle = dgvCellStyleRegion;
            dgvBranchOffice.Columns.Add(colRegion);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvBranchOffice.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvBranchOffice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvBranchOffice.AutoGenerateColumns = false;
            dgvBranchOffice.AllowUserToAddRows = false;
            dgvBranchOffice.AllowUserToResizeColumns = false;
            dgvBranchOffice.AllowUserToResizeRows = false;
            dgvBranchOffice.RowHeadersVisible = false;
            dgvBranchOffice.BackgroundColor = Color.White;
            dgvBranchOffice.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = BranchOfficeDAO.BranchOffice_GetAll();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dgvBranchOffice.DataSource = dt.Copy();
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                BranchOfficeDTO objBranch = new BranchOfficeDTO();
                objBranch.ID = -1;
                objBranch.Name = txtName.Text;
                objBranch.Phone = txtPhone.Text;
                objBranch.Fax = txtFax.Text;
                objBranch.IDLocation = Convert.ToInt64((cboLocation.SelectedItem as clsComboItem).Value);

                ds = BranchOfficeDAO.BranchOffice_Search(objBranch);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvBranchOffice.DataSource = ds.Tables[0].Copy();
                }
                else
                {
                    clsMessages.ShowWarning("Không tìm thấy");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBranchOfficeInsUpd frm = new frmBranchOfficeInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                BranchOfficeDTO obj = new BranchOfficeDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.Name = txtName.Text;
                obj.Phone = txtPhone.Text;
                obj.Fax = txtFax.Text;
                obj.IDLocation = Convert.ToInt64((cboLocation.SelectedItem as clsComboItem).Value);

                ds = BranchOfficeDAO.BranchOffice_InsUpd(obj);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0]["Result"]) == 1)
                {
                    clsMessages.ShowInformation("Cập nhật thành công!");
                    LoadDataToForm();
                }
                else
                {
                    clsMessages.ShowWarning("Cập nhật thất bại!");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn xóa!");
                    return;
                }
                long lID = Convert.ToInt64(txtID.Text);

                ds = BranchOfficeDAO.BranchOffice_Del(lID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0]["Result"]) == 1)
                {
                    clsMessages.ShowInformation("Xóa thành công!");
                    LoadDataToForm();
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

        #region Gridview
        private void dgvBranchOffice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvBranchOffice.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvBranchOffice.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString().Trim();
                txtFax.Text = row.Cells[3].Value.ToString().Trim();
                object objLocationID = row.Cells[4].Value;
                clsComboItem item = clsComboItem.GetItemCombo(objLocationID, cboLocation);
                cboLocation.SelectedItem = item;
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
