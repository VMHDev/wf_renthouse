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
    public partial class frmContract : Form
    {
        #region Form
        public frmContract()
        {
            InitializeComponent();
            dtpContractDate.Value = DateTime.Now;
        }

        private void frmContract_Load(object sender, EventArgs e)
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
            DataGridViewColumn colIDHouse = new DataGridViewTextBoxColumn();
            colIDHouse.DataPropertyName = "IDHouse";
            colIDHouse.HeaderText = "ID Nhà";
            colIDHouse.Name = "colIDHouse";
            colIDHouse.ReadOnly = true;
            colIDHouse.Visible = false;
            dgvContract.Columns.Add(colIDHouse);
            #endregion

            #region Mã nhà
            DataGridViewColumn colCodeHouse = new DataGridViewTextBoxColumn();
            colCodeHouse.DataPropertyName = "CodeHouse";
            colCodeHouse.HeaderText = "Mã nhà";
            colCodeHouse.Name = "colCodeHouse";
            colCodeHouse.ReadOnly = true;
            colCodeHouse.Visible = true;
            colCodeHouse.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleCodeHouse = new DataGridViewCellStyle();
            dgvCellStyleCodeHouse.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleCodeHouse.Font = new Font("Arial", 12F);
            colCodeHouse.DefaultCellStyle = dgvCellStyleCodeHouse;
            dgvContract.Columns.Add(colCodeHouse);
            #endregion

            #region Số phòng
            DataGridViewColumn colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomNumber.DataPropertyName = "RoomNumber";
            colRoomNumber.HeaderText = "Số phòng";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            colRoomNumber.Visible = true;
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleRoomNumber = new DataGridViewCellStyle();
            dgvCellStyleRoomNumber.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleRoomNumber.Font = new Font("Arial", 12F);
            colRoomNumber.DefaultCellStyle = dgvCellStyleRoomNumber;
            dgvContract.Columns.Add(colRoomNumber);
            #endregion

            #region Phí một tháng
            DataGridViewColumn colFeeMonth = new DataGridViewTextBoxColumn();
            colFeeMonth.DataPropertyName = "FeeMonth";
            colFeeMonth.HeaderText = "Phí một tháng";
            colFeeMonth.Name = "colFeeMonth";
            colFeeMonth.ReadOnly = true;
            colFeeMonth.Visible = true;
            colFeeMonth.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleFeeMonth = new DataGridViewCellStyle();
            dgvCellStyleFeeMonth.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleFeeMonth.Font = new Font("Arial", 12F);
            colFeeMonth.DefaultCellStyle = dgvCellStyleFeeMonth;
            dgvContract.Columns.Add(colFeeMonth);
            #endregion

            #region ID Khách
            DataGridViewColumn colIDCustomer = new DataGridViewTextBoxColumn();
            colIDCustomer.DataPropertyName = "IDCustomer";
            colIDCustomer.HeaderText = "ID Khách";
            colIDCustomer.Name = "colIDCustomer";
            colIDCustomer.ReadOnly = true;
            colIDCustomer.Visible = false;
            dgvContract.Columns.Add(colIDCustomer);
            #endregion

            #region Tên khách
            DataGridViewColumn colNameCustomer = new DataGridViewTextBoxColumn();
            colNameCustomer.DataPropertyName = "NameCustomer";
            colNameCustomer.HeaderText = "Tên khách";
            colNameCustomer.Name = "colNameCustomer";
            colNameCustomer.ReadOnly = true;
            colNameCustomer.Visible = true;
            colNameCustomer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleNameCustomer = new DataGridViewCellStyle();
            dgvCellStyleNameCustomer.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleNameCustomer.Font = new Font("Arial", 12F);
            colNameCustomer.DefaultCellStyle = dgvCellStyleNameCustomer;
            dgvContract.Columns.Add(colNameCustomer);
            #endregion

            #region Ngày lập hợp đồng
            DataGridViewColumn colContractDate = new DataGridViewTextBoxColumn();
            colContractDate.DataPropertyName = "ContractDate";
            colContractDate.HeaderText = "Ngày lập hợp đồng";
            colContractDate.Name = "colContractDate";
            colContractDate.ReadOnly = true;
            colContractDate.Visible = true;
            colContractDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleContractDate = new DataGridViewCellStyle();
            dgvCellStyleContractDate.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleContractDate.Font = new Font("Arial", 12F);
            colContractDate.DefaultCellStyle = dgvCellStyleContractDate;
            dgvContract.Columns.Add(colContractDate);
            #endregion

            #region ID Nhân viên
            DataGridViewColumn colIDEmployee = new DataGridViewTextBoxColumn();
            colIDEmployee.DataPropertyName = "IDEmployee";
            colIDEmployee.HeaderText = "ID Nhân viên";
            colIDEmployee.Name = "colIDEmployee";
            colIDEmployee.ReadOnly = true;
            colIDEmployee.Visible = false;
            dgvContract.Columns.Add(colIDEmployee);
            #endregion

            #region Tên Nhân viên
            DataGridViewColumn colNameEmployee = new DataGridViewTextBoxColumn();
            colNameEmployee.DataPropertyName = "NameEmployee";
            colNameEmployee.HeaderText = "Tên Nhân viên";
            colNameEmployee.Name = "colNameEmployee";
            colNameEmployee.ReadOnly = true;
            colNameEmployee.Visible = true;
            colNameEmployee.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleNameEmployee = new DataGridViewCellStyle();
            dgvCellStyleNameEmployee.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleNameEmployee.Font = new Font("Arial", 12F);
            colNameEmployee.DefaultCellStyle = dgvCellStyleNameEmployee;
            dgvContract.Columns.Add(colNameEmployee);
            # endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvContract.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvContract.AutoGenerateColumns = false;
            dgvContract.AllowUserToAddRows = false;
            dgvContract.AllowUserToResizeColumns = false;
            dgvContract.AllowUserToResizeRows = false;
            dgvContract.RowHeadersVisible = false;
            dgvContract.BackgroundColor = Color.White;
            dgvContract.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            cboCustomer.SelectedIndex = -1;
            cboEmployee.SelectedIndex = -1;
            cboHouse.SelectedIndex = -1;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = ContractDAO.Contract_GetAll().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dgvContract.DataSource = dt.Copy();
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

                cboStatus.Items.Add(new clsComboItem("C", "Hoàn tất"));
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
                ContractDTO obj = new ContractDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.IDEmployee = Convert.ToInt64((cboEmployee.SelectedItem as clsComboItem).Value);
                obj.ContractDate = dtpContractDate.Value.Date;

                ds = ContractDAO.Contract_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvContract.DataSource = ds.Tables[0].Copy();
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
            frmContractInsUpd frm = new frmContractInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (string.IsNullOrWhiteSpace(cboCustomer.Text) || string.IsNullOrWhiteSpace(cboHouse.Text) || string.IsNullOrWhiteSpace(cboEmployee.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn cập nhật!");
                    return;
                }
                ContractDTO obj = new ContractDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.IDEmployee = Convert.ToInt64((cboEmployee.SelectedItem as clsComboItem).Value);

                ds = ContractDAO.Contract_InsUpd(obj);
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
                if (string.IsNullOrWhiteSpace(cboCustomer.Text) || string.IsNullOrWhiteSpace(cboHouse.Text) || string.IsNullOrWhiteSpace(cboEmployee.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn xóa!");
                    return;
                }
                ContractDTO obj = new ContractDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.IDEmployee = Convert.ToInt64((cboEmployee.SelectedItem as clsComboItem).Value);


                ds = ContractDAO.Contract_Del(obj);
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
        private void dgvContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvContract.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvContract.Rows[e.RowIndex];
                object objIDHouse = row.Cells[0].Value;
                clsComboItem itemHouse = clsComboItem.GetItemCombo(objIDHouse, cboHouse);
                cboHouse.SelectedItem = itemHouse;

                object objIDCustomer = row.Cells[4].Value;
                clsComboItem itemCustomer = clsComboItem.GetItemCombo(objIDCustomer, cboCustomer);
                cboCustomer.SelectedItem = itemCustomer;

                dtpContractDate.Text = row.Cells[6].Value.ToString();

                object objIDEmployee = row.Cells[7].Value;
                clsComboItem itemEmployee = clsComboItem.GetItemCombo(objIDEmployee, cboEmployee);
                cboEmployee.SelectedItem = itemEmployee;

                clsComboItem itemStatus = clsComboItem.GetItemCombo("C", cboStatus);
                cboStatus.SelectedItem = itemStatus;
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
