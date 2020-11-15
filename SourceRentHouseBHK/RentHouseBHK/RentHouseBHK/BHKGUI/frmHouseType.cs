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
    public partial class frmHouseType : Form
    {
        #region Form
        public frmHouseType()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmHouseType_Load(object sender, EventArgs e)
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
            #region ID Loại nhà
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Loại nhà";
            colID.Name = "colHouseTypeID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvHouseType.Columns.Add(colID);
            #endregion

            #region Tên Loại nhà
            DataGridViewColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Tên Loại nhà";
            colName.Name = "colHouseTypeName";
            colName.ReadOnly = true;
            colName.Visible = true;
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleName = new DataGridViewCellStyle();
            dgvCellStyleName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleName.Font = new Font("Arial", 12F);
            colName.DefaultCellStyle = dgvCellStyleName;
            dgvHouseType.Columns.Add(colName);
            #endregion

            #region Mô tả
            DataGridViewColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Mô tả";
            colDescription.Name = "colHouseTypeDescription";
            colDescription.ReadOnly = true;
            colDescription.Visible = true;
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleDescription = new DataGridViewCellStyle();
            dgvCellStyleDescription.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleDescription.Font = new Font("Arial", 12F);
            colDescription.DefaultCellStyle = dgvCellStyleDescription;
            dgvHouseType.Columns.Add(colDescription);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvHouseType.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvHouseType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvHouseType.AutoGenerateColumns = false;
            dgvHouseType.AllowUserToAddRows = false;
            dgvHouseType.AllowUserToResizeColumns = false;
            dgvHouseType.AllowUserToResizeRows = false;
            dgvHouseType.RowHeadersVisible = false;
            dgvHouseType.BackgroundColor = Color.White;
            dgvHouseType.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = HouseTypeDAO.HouseType_GetAll().Tables[0].Copy();
                dgvHouseType.DataSource = dt;
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
                HouseTypeDTO obj = new HouseTypeDTO();
                obj.ID = -1;
                obj.Description = txtDescription.Text;
                obj.Name = txtName.Text;

                ds = HouseTypeDAO.HouseType_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvHouseType.DataSource = ds.Tables[0].Copy();
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
            frmHouseTypeInsUpd frm = new frmHouseTypeInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                HouseTypeDTO obj = new HouseTypeDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.Description = txtDescription.Text;
                obj.Name = txtName.Text;

                ds = HouseTypeDAO.HouseType_InsUpd(obj);
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

                ds = HouseTypeDAO.HouseType_Del(lID);
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
        private void dgvHouseType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvHouseType.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvHouseType.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
