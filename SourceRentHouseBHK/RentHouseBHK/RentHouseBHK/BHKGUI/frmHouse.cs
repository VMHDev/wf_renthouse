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
    public partial class frmHouse : Form
    {
        #region Form
        public frmHouse()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
        }

        private void frmHouse_Load(object sender, EventArgs e)
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
            #region ID Nhà
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Nhà";
            colID.Name = "colHouseID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvHouse.Columns.Add(colID);
            #endregion

            #region Số phòng
            DataGridViewColumn colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomNumber.DataPropertyName = "RoomNumber";
            colRoomNumber.HeaderText = "Số phòng";
            colRoomNumber.Name = "colHouseRoomNumber";
            colRoomNumber.ReadOnly = true;
            colRoomNumber.Visible = true;
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleName = new DataGridViewCellStyle();
            dgvCellStyleName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleName.Font = new Font("Arial", 12F);
            colRoomNumber.DefaultCellStyle = dgvCellStyleName;
            dgvHouse.Columns.Add(colRoomNumber);
            #endregion

            #region Phí thuê một tháng
            DataGridViewColumn colFeeMonth = new DataGridViewTextBoxColumn();
            colFeeMonth.DataPropertyName = "FeeMonth";
            colFeeMonth.HeaderText = "Phí thuê một tháng";
            colFeeMonth.Name = "colHouseFeeMonth";
            colFeeMonth.ReadOnly = true;
            colFeeMonth.Visible = true;
            colFeeMonth.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleFeeMonth = new DataGridViewCellStyle();
            dgvCellStyleFeeMonth.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleFeeMonth.Font = new Font("Arial", 12F);
            colFeeMonth.DefaultCellStyle = dgvCellStyleFeeMonth;
            dgvHouse.Columns.Add(colFeeMonth);
            #endregion

            #region ID Chủ nhà
            DataGridViewColumn colIDHouseholder = new DataGridViewTextBoxColumn();
            colIDHouseholder.DataPropertyName = "IDHouseholder";
            colIDHouseholder.HeaderText = "ID Chủ nhà";
            colIDHouseholder.Name = "colIDHouseholder";
            colIDHouseholder.ReadOnly = true;
            colIDHouseholder.Visible = false;
            dgvHouse.Columns.Add(colIDHouseholder);
            #endregion

            #region Tên Chủ nhà
            DataGridViewColumn colHouseholderName = new DataGridViewTextBoxColumn();
            colHouseholderName.DataPropertyName = "HouseholderName";
            colHouseholderName.HeaderText = "Chủ nhà";
            colHouseholderName.Name = "colHouseholderName";
            colHouseholderName.ReadOnly = true;
            colHouseholderName.Visible = true;
            colHouseholderName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleHouseholderName = new DataGridViewCellStyle();
            dgvCellStyleHouseholderName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleHouseholderName.Font = new Font("Arial", 12F);
            colHouseholderName.DefaultCellStyle = dgvCellStyleHouseholderName;
            dgvHouse.Columns.Add(colHouseholderName);
            #endregion

            #region ID Nhân viên
            DataGridViewColumn colIDEmployee = new DataGridViewTextBoxColumn();
            colIDEmployee.DataPropertyName = "IDEmployee";
            colIDEmployee.HeaderText = "ID Nhân viên";
            colIDEmployee.Name = "colIDEmployee";
            colIDEmployee.ReadOnly = true;
            colIDEmployee.Visible = false;
            dgvHouse.Columns.Add(colIDEmployee);
            #endregion

            #region Tên Nhân viên
            DataGridViewColumn colEmployeeName = new DataGridViewTextBoxColumn();
            colEmployeeName.DataPropertyName = "EmployeeName";
            colEmployeeName.HeaderText = "Nhân viên";
            colEmployeeName.Name = "colEmployeeName";
            colEmployeeName.ReadOnly = true;
            colEmployeeName.Visible = true;
            colEmployeeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleEmployeeName = new DataGridViewCellStyle();
            dgvCellStyleEmployeeName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleEmployeeName.Font = new Font("Arial", 12F);
            colEmployeeName.DefaultCellStyle = dgvCellStyleEmployeeName;
            dgvHouse.Columns.Add(colEmployeeName);
            #endregion

            #region ID Loại nhà
            DataGridViewColumn colIDHouseType = new DataGridViewTextBoxColumn();
            colIDHouseType.DataPropertyName = "IDHouseType";
            colIDHouseType.HeaderText = "ID Loại nhà";
            colIDHouseType.Name = "colIDHouseType";
            colIDHouseType.ReadOnly = true;
            colIDHouseType.Visible = false;
            dgvHouse.Columns.Add(colIDHouseType);
            #endregion

            #region Tên Loại nhà
            DataGridViewColumn colHouseTypeName = new DataGridViewTextBoxColumn();
            colHouseTypeName.DataPropertyName = "HouseTypeName";
            colHouseTypeName.HeaderText = "Loại nhà";
            colHouseTypeName.Name = "colHouseTypeName";
            colHouseTypeName.ReadOnly = true;
            colHouseTypeName.Visible = true;
            colHouseTypeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleHouseType = new DataGridViewCellStyle();
            dgvCellStyleHouseType.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleHouseType.Font = new Font("Arial", 12F);
            colHouseTypeName.DefaultCellStyle = dgvCellStyleHouseType;
            dgvHouse.Columns.Add(colHouseTypeName);
            #endregion

            #region ID Địa chỉ
            DataGridViewColumn colIDLocation = new DataGridViewTextBoxColumn();
            colIDLocation.DataPropertyName = "IDLocation";
            colIDLocation.HeaderText = "ID Địa chỉ";
            colIDLocation.Name = "colIDLocation";
            colIDLocation.ReadOnly = true;
            colIDLocation.Visible = false;
            dgvHouse.Columns.Add(colIDLocation);
            #endregion

            #region Địa chỉ
            DataGridViewColumn colAddress = new DataGridViewTextBoxColumn();
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Địa chỉ";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            colAddress.Visible = true;
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleAddress = new DataGridViewCellStyle();
            dgvCellStyleAddress.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleAddress.Font = new Font("Arial", 12F);
            colAddress.DefaultCellStyle = dgvCellStyleAddress;
            dgvHouse.Columns.Add(colAddress);
            #endregion

            #region Khu vực
            DataGridViewColumn colRegion = new DataGridViewTextBoxColumn();
            colRegion.DataPropertyName = "Region";
            colRegion.HeaderText = "Khu vực";
            colRegion.Name = "colRegion";
            colRegion.ReadOnly = true;
            colRegion.Visible = true;
            colRegion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleRegion = new DataGridViewCellStyle();
            dgvCellStyleRegion.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleRegion.Font = new Font("Arial", 12F);
            colRegion.DefaultCellStyle = dgvCellStyleRegion;
            dgvHouse.Columns.Add(colRegion);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvHouse.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvHouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvHouse.AutoGenerateColumns = false;
            dgvHouse.AllowUserToAddRows = false;
            dgvHouse.AllowUserToResizeColumns = false;
            dgvHouse.AllowUserToResizeRows = false;
            dgvHouse.RowHeadersVisible = false;
            dgvHouse.BackgroundColor = Color.White;
            dgvHouse.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = HouseDAO.House_GetAll();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dgvHouse.DataSource = dt.Copy();
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
        private void btnSearch_Click(object sender, EventArgs e)
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

                ds = HouseDAO.House_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvHouse.DataSource = ds.Tables[0].Copy();
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
            frmHouseInsUpd frm = new frmHouseInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                HouseDTO obj = new HouseDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.FeeMonth = string.IsNullOrWhiteSpace(txtFeeMonth.Text) ? -1 : Convert.ToInt32(txtFeeMonth.Text);
                obj.RoomNumber = string.IsNullOrWhiteSpace(txtRoomNumber.Text) ? -1 : Convert.ToInt32(txtRoomNumber.Text);
                obj.IDEmployee = Convert.ToInt64((cboEmployee.SelectedItem as clsComboItem).Value);
                obj.IDHouseholder = Convert.ToInt64((cboHouseholder.SelectedItem as clsComboItem).Value);
                obj.IDHouseType = Convert.ToInt64((cboHouseType.SelectedItem as clsComboItem).Value);
                obj.IDLocation = Convert.ToInt64((cboLocation.SelectedItem as clsComboItem).Value);

                ds = HouseDAO.House_InsUpd(obj);
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

                ds = HouseDAO.House_Del(lID);
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
        private void dgvHouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvHouse.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvHouse.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtRoomNumber.Text = row.Cells[1].Value.ToString();
                txtFeeMonth.Text = row.Cells[2].Value.ToString();

                object objIDHouseholder = row.Cells[3].Value;
                clsComboItem itemHouseholder = clsComboItem.GetItemCombo(objIDHouseholder, cboHouseholder);
                cboHouseholder.SelectedItem = itemHouseholder;

                object objIDEmployee = row.Cells[5].Value;
                clsComboItem itemEmployee = clsComboItem.GetItemCombo(objIDEmployee, cboEmployee);
                cboEmployee.SelectedItem = itemEmployee;

                object objHouseType = row.Cells[7].Value;
                clsComboItem itemHouseType = clsComboItem.GetItemCombo(objHouseType, cboHouseType);
                cboHouseType.SelectedItem = itemHouseType;

                object objIDLocation = row.Cells[9].Value;
                clsComboItem itemIDLocation = clsComboItem.GetItemCombo(objIDLocation, cboLocation);
                cboLocation.SelectedItem = itemIDLocation;
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
