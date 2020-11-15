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
    public partial class frmLocation : Form
    {
        #region Form
        public frmLocation()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            InitColumnGridView();
            LoadDataToForm();
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
            #region ID Địa điểm
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Địa điểm";
            colID.Name = "colLocationID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvLocation.Columns.Add(colID);
            #endregion

            #region Tên đường
            DataGridViewColumn colStreetName = new DataGridViewTextBoxColumn();
            colStreetName.DataPropertyName = "StreetName";
            colStreetName.HeaderText = "Tên đường";
            colStreetName.Name = "colStreetName";
            colStreetName.ReadOnly = true;
            colStreetName.Visible = true;
            colStreetName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleStreetName = new DataGridViewCellStyle();
            dgvCellStyleStreetName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleStreetName.Font = new Font("Arial", 12F);
            colStreetName.DefaultCellStyle = dgvCellStyleStreetName;
            dgvLocation.Columns.Add(colStreetName);
            #endregion

            #region Quận
            DataGridViewColumn colDistrict = new DataGridViewTextBoxColumn();
            colDistrict.DataPropertyName = "District";
            colDistrict.HeaderText = "Quận";
            colDistrict.Name = "colLocationDistrict";
            colDistrict.ReadOnly = true;
            colDistrict.Visible = true;
            colDistrict.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleDistrict = new DataGridViewCellStyle();
            dgvCellStyleDistrict.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleDistrict.Font = new Font("Arial", 12F);
            colDistrict.DefaultCellStyle = dgvCellStyleDistrict;
            dgvLocation.Columns.Add(colDistrict);
            #endregion

            #region Thành phố
            DataGridViewColumn colCity = new DataGridViewTextBoxColumn();
            colCity.DataPropertyName = "City";
            colCity.HeaderText = "Thành phố";
            colCity.Name = "colLocationCity";
            colCity.ReadOnly = true;
            colCity.Visible = true;
            colCity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleCity = new DataGridViewCellStyle();
            dgvCellStyleCity.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleCity.Font = new Font("Arial", 12F);
            colCity.DefaultCellStyle = dgvCellStyleCity;
            dgvLocation.Columns.Add(colCity);
            #endregion

            #region Khu vực
            DataGridViewColumn colRegion = new DataGridViewTextBoxColumn();
            colRegion.DataPropertyName = "Region";
            colRegion.HeaderText = "Khu vực";
            colRegion.Name = "colLocationRegion";
            colRegion.ReadOnly = true;
            colRegion.Visible = true;
            colRegion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleRegion = new DataGridViewCellStyle();
            dgvCellStyleRegion.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleRegion.Font = new Font("Arial", 12F);
            colRegion.DefaultCellStyle = dgvCellStyleRegion;
            dgvLocation.Columns.Add(colRegion);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvLocation.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvLocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvLocation.AutoGenerateColumns = false;
            dgvLocation.AllowUserToAddRows = false;
            dgvLocation.AllowUserToResizeColumns = false;
            dgvLocation.AllowUserToResizeRows = false;
            dgvLocation.RowHeadersVisible = false;
            dgvLocation.BackgroundColor = Color.White;
            dgvLocation.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = LocationDAO.Location_GetAll().Tables[0].Copy();
                dgvLocation.DataSource = dt;
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion

        #region Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                LocationDTO obj = new LocationDTO();
                obj.ID = -1;
                obj.City = txtCity.Text;
                obj.District = txtDistrict.Text;
                obj.Region = txtRegion.Text;
                obj.StreetName = txtStreetName.Text;

                ds = LocationDAO.Location_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvLocation.DataSource = ds.Tables[0].Copy();
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
            frmLocationInsUpd frm = new frmLocationInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                LocationDTO obj = new LocationDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.City = txtCity.Text;
                obj.District = txtDistrict.Text;
                obj.Region = txtRegion.Text;
                obj.StreetName = txtStreetName.Text;

                ds = LocationDAO.Location_InsUpd(obj);
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

                ds = LocationDAO.Location_Del(lID);
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
        private void dgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvLocation.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvLocation.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtStreetName.Text = row.Cells[1].Value.ToString();
                txtDistrict.Text = row.Cells[2].Value.ToString();
                txtCity.Text = row.Cells[3].Value.ToString();
                txtRegion.Text = row.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
