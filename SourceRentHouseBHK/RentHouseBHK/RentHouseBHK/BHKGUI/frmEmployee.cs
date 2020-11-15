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
    public partial class frmEmployee : Form
    {
        #region Form
        public frmEmployee()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
            chkFemale.Checked = true;
            dtpBirthday.Value = DateTime.Now;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
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
            #region ID Nhân viên
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Nhân viên";
            colID.Name = "colEmployeeID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvEmployee.Columns.Add(colID);
            #endregion

            #region Tên Nhân viên
            DataGridViewColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Tên nhân viên";
            colName.Name = "colEmployeeName";
            colName.ReadOnly = true;
            colName.Visible = true;
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleName = new DataGridViewCellStyle();
            dgvCellStyleName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleName.Font = new Font("Arial", 12F);
            colName.DefaultCellStyle = dgvCellStyleName;
            dgvEmployee.Columns.Add(colName);
            #endregion

            #region Địa chỉ
            DataGridViewColumn colAddress = new DataGridViewTextBoxColumn();
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Địa chỉ";
            colAddress.Name = "colEmployeeAddress";
            colAddress.ReadOnly = true;
            colAddress.Visible = true;
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleAddress = new DataGridViewCellStyle();
            dgvCellStyleAddress.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleAddress.Font = new Font("Arial", 12F);
            colAddress.DefaultCellStyle = dgvCellStyleAddress;
            dgvEmployee.Columns.Add(colAddress);
            #endregion

            #region Số điện thoại
            DataGridViewColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "Số điện thoại";
            colPhone.Name = "colEmployeePhone";
            colPhone.ReadOnly = true;
            colPhone.Visible = true;
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStylePhone = new DataGridViewCellStyle();
            dgvCellStylePhone.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStylePhone.Font = new Font("Arial", 12F);
            colPhone.DefaultCellStyle = dgvCellStylePhone;
            dgvEmployee.Columns.Add(colPhone);
            #endregion

            #region Giới tính
            DataGridViewColumn colGender = new DataGridViewCheckBoxColumn();
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "Giới tính";
            colGender.Name = "colEmployeeGender";
            colGender.ReadOnly = true;
            colGender.Visible = true;
            colGender.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployee.Columns.Add(colGender);
            #endregion

            #region Ngày sinh
            DataGridViewColumn colBirthday = new DataGridViewTextBoxColumn();
            colBirthday.DataPropertyName = "Birthday";
            colBirthday.HeaderText = "Ngày sinh";
            colBirthday.Name = "colEmployeeBirthday";
            colBirthday.ReadOnly = true;
            colBirthday.Visible = true;
            colBirthday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleBirthday = new DataGridViewCellStyle();
            dgvCellStyleBirthday.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleBirthday.Font = new Font("Arial", 12F);
            colBirthday.DefaultCellStyle = dgvCellStyleBirthday;
            dgvEmployee.Columns.Add(colBirthday);
            #endregion

            #region Lương
            DataGridViewColumn colSalary = new DataGridViewTextBoxColumn();
            colSalary.DataPropertyName = "Salary";
            colSalary.HeaderText = "Lương";
            colSalary.Name = "colEmployeeSalary";
            colSalary.ReadOnly = true;
            colSalary.Visible = true;
            colSalary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleSalary = new DataGridViewCellStyle();
            dgvCellStyleSalary.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleSalary.Font = new Font("Arial", 12F);
            colSalary.DefaultCellStyle = dgvCellStyleSalary;
            dgvEmployee.Columns.Add(colSalary);
            #endregion

            #region ID Chi nhánh
            DataGridViewColumn colIDBranchOffice = new DataGridViewTextBoxColumn();
            colIDBranchOffice.DataPropertyName = "IDBranchOffice";
            colIDBranchOffice.HeaderText = "ID Chi nhánh";
            colIDBranchOffice.Name = "colIDBranchOffice";
            colIDBranchOffice.ReadOnly = true;
            colIDBranchOffice.Visible = false;
            dgvEmployee.Columns.Add(colIDBranchOffice);
            #endregion

            #region Tên chi nhánh
            DataGridViewColumn colBranchOfficeName = new DataGridViewTextBoxColumn();
            colBranchOfficeName.DataPropertyName = "BranchOfficeName";
            colBranchOfficeName.HeaderText = "Tên chi nhánh";
            colBranchOfficeName.Name = "colBranchOfficeName";
            colBranchOfficeName.ReadOnly = true;
            colBranchOfficeName.Visible = true;
            colBranchOfficeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleBranchOfficeName = new DataGridViewCellStyle();
            dgvCellStyleBranchOfficeName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleBranchOfficeName.Font = new Font("Arial", 12F);
            colBranchOfficeName.DefaultCellStyle = dgvCellStyleBranchOfficeName;
            dgvEmployee.Columns.Add(colBranchOfficeName);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvEmployee.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToResizeColumns = false;
            dgvEmployee.AllowUserToResizeRows = false;
            dgvEmployee.RowHeadersVisible = false;
            dgvEmployee.BackgroundColor = Color.White;
            dgvEmployee.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = EmployeeDAO.Employee_GetAll().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dgvEmployee.DataSource = dt.Copy();
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

        public void ClearData()
        {
            txtAddress.Text = string.Empty;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSalary.Text = string.Empty;
            dtpBirthday.Value = DateTime.Now;
            cboBranchOffice.SelectedIndex = 0;
            chkFemale.Checked = false;

        }
        #endregion

        #region Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                EmployeeDTO obj = new EmployeeDTO();
                obj.ID = -1;
                obj.Name = txtName.Text.Trim();
                obj.Phone = txtPhone.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
                obj.Birthday = dtpBirthday.Value.Date;
                string sSalary = string.IsNullOrWhiteSpace(txtSalary.Text) ? "0" : txtSalary.Text;
                obj.Salary = Convert.ToDecimal(sSalary) == 0 ? -1 : Convert.ToDecimal(sSalary);
                obj.Gender = chkFemale.Checked;
                obj.IDBranchOffice = Convert.ToInt64((cboBranchOffice.SelectedItem as clsComboItem).Value);

                ds = EmployeeDAO.Employee_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvEmployee.DataSource = ds.Tables[0].Copy();
                    ClearData();
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
            frmEmployeeInsUpd frm = new frmEmployeeInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                EmployeeDTO obj = new EmployeeDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.Name = txtName.Text;
                obj.Phone = txtPhone.Text;
                obj.Address = txtAddress.Text;
                obj.Birthday = dtpBirthday.Value.Date;
                obj.Salary = Convert.ToDecimal(txtSalary.Text);
                obj.Gender = chkFemale.Checked;
                obj.IDBranchOffice = Convert.ToInt64((cboBranchOffice.SelectedItem as clsComboItem).Value);

                ds = EmployeeDAO.Employee_InsUpd(obj);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0]["Result"]) == 1)
                {
                    clsMessages.ShowInformation("Cập nhật thành công!");
                    LoadDataToForm();
                    ClearData();
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

                ds = EmployeeDAO.Employee_Del(lID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0]["Result"]) == 1)
                {
                    clsMessages.ShowInformation("Xóa thành công!");
                    LoadDataToForm();
                    ClearData();
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
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvEmployee.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                txtPhone.Text = row.Cells[3].Value.ToString();
                string sGender = row.Cells[4].Value.ToString();
                chkFemale.Checked = sGender == "True" ? true : false;
                string sBirthday = row.Cells[5].Value.ToString();
                dtpBirthday.Text = sBirthday;
                txtSalary.Text = row.Cells[6].Value.ToString();
                object objIDBranchOffice = row.Cells[7].Value;
                clsComboItem item = clsComboItem.GetItemCombo(objIDBranchOffice, cboBranchOffice);
                cboBranchOffice.SelectedItem = item;
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
