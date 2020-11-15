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
    public partial class frmHouseholder : Form
    {
        #region Form
        public frmHouseholder()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmHouseholder_Load(object sender, EventArgs e)
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
            #region ID Chủ nhà
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Chủ nhà";
            colID.Name = "colHouseholderID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvHouseholder.Columns.Add(colID);
            #endregion

            #region Tên Chủ nhà
            DataGridViewColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Tên Chủ nhà";
            colName.Name = "colHouseholderName";
            colName.ReadOnly = true;
            colName.Visible = true;
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleName = new DataGridViewCellStyle();
            dgvCellStyleName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleName.Font = new Font("Arial", 12F);
            colName.DefaultCellStyle = dgvCellStyleName;
            dgvHouseholder.Columns.Add(colName);
            #endregion

            #region Số điện thoại
            DataGridViewColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "Số điện thoại";
            colPhone.Name = "colHouseholderPhone";
            colPhone.ReadOnly = true;
            colPhone.Visible = true;
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStylePhone = new DataGridViewCellStyle();
            dgvCellStylePhone.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStylePhone.Font = new Font("Arial", 12F);
            colPhone.DefaultCellStyle = dgvCellStylePhone;
            dgvHouseholder.Columns.Add(colPhone);
            #endregion

            #region Địa chỉ
            DataGridViewColumn colAddress = new DataGridViewTextBoxColumn();
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Địa chỉ";
            colAddress.Name = "colHouseholderAddress";
            colAddress.ReadOnly = true;
            colAddress.Visible = true;
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleAddress = new DataGridViewCellStyle();
            dgvCellStyleAddress.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleAddress.Font = new Font("Arial", 12F);
            colAddress.DefaultCellStyle = dgvCellStyleAddress;
            dgvHouseholder.Columns.Add(colAddress);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvHouseholder.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvHouseholder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvHouseholder.AutoGenerateColumns = false;
            dgvHouseholder.AllowUserToAddRows = false;
            dgvHouseholder.AllowUserToResizeColumns = false;
            dgvHouseholder.AllowUserToResizeRows = false;
            dgvHouseholder.RowHeadersVisible = false;
            dgvHouseholder.BackgroundColor = Color.White;
            dgvHouseholder.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = HouseholderDAO.Householder_GetAll().Tables[0].Copy();
                dgvHouseholder.DataSource = dt;
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
                HouseholderDTO obj = new HouseholderDTO();
                obj.ID = -1;
                obj.Name = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;

                ds = HouseholderDAO.Householder_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvHouseholder.DataSource = ds.Tables[0].Copy();
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
            frmHouseholderInsUpd frm = new frmHouseholderInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                HouseholderDTO obj = new HouseholderDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.Name = txtName.Text;
                obj.Address = txtAddress.Text;
                obj.Phone = txtPhone.Text;

                ds = HouseholderDAO.Householder_InsUpd(obj);
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

                ds = HouseholderDAO.Householder_Del(lID);
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
        private void dgvHouseholder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvHouseholder.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvHouseholder.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString().Trim();
                txtAddress.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
