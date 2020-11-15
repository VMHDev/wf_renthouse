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
    public partial class frmCustomer : Form
    {
        #region Form
        public frmCustomer()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            txtID.TabStop = false;
            chkAbilityRent.Checked = true;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
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
            #region ID Khách hàng
            DataGridViewColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID Khách hàng";
            colID.Name = "colCustomerID";
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvCustomer.Columns.Add(colID);
            #endregion

            #region Tên Khách hàng
            DataGridViewColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Tên Khách hàng";
            colName.Name = "colCustomerName";
            colName.ReadOnly = true;
            colName.Visible = true;
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleName = new DataGridViewCellStyle();
            dgvCellStyleName.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleName.Font = new Font("Arial", 12F);
            colName.DefaultCellStyle = dgvCellStyleName;
            dgvCustomer.Columns.Add(colName);
            #endregion

            #region Số điện thoại
            DataGridViewColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "Số điện thoại";
            colPhone.Name = "colCustomerPhone";
            colPhone.ReadOnly = true;
            colPhone.Visible = true;
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStylePhone = new DataGridViewCellStyle();
            dgvCellStylePhone.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStylePhone.Font = new Font("Arial", 12F);
            colPhone.DefaultCellStyle = dgvCellStylePhone;
            dgvCustomer.Columns.Add(colPhone);
            #endregion

            #region Địa chỉ
            DataGridViewColumn colAddress = new DataGridViewTextBoxColumn();
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Địa chỉ";
            colAddress.Name = "colCustomerAddress";
            colAddress.ReadOnly = true;
            colAddress.Visible = true;
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleAddress = new DataGridViewCellStyle();
            dgvCellStyleAddress.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleAddress.Font = new Font("Arial", 12F);
            colAddress.DefaultCellStyle = dgvCellStyleAddress;
            dgvCustomer.Columns.Add(colAddress);
            #endregion

            #region Yêu cầu
            DataGridViewColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Yêu cầu";
            colDescription.Name = "colCustomerDescription";
            colDescription.ReadOnly = true;
            colDescription.Visible = true;
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleDescription = new DataGridViewCellStyle();
            dgvCellStyleDescription.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleDescription.Font = new Font("Arial", 12F);
            colDescription.DefaultCellStyle = dgvCellStyleDescription;
            dgvCustomer.Columns.Add(colDescription);
            #endregion

            #region Khả năng thuê
            DataGridViewColumn colAbilityRent = new DataGridViewCheckBoxColumn();
            colAbilityRent.DataPropertyName = "AbilityRent";
            colAbilityRent.HeaderText = "Khả năng thuê";
            colAbilityRent.Name = "colCustomerAbilityRent";
            colAbilityRent.ReadOnly = true;
            colAbilityRent.Visible = true;
            colAbilityRent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns.Add(colAbilityRent);
            #endregion

            #region ID Chi nhánh
            DataGridViewColumn colIDBranchOffice = new DataGridViewTextBoxColumn();
            colIDBranchOffice.DataPropertyName = "IDBranchOffice";
            colIDBranchOffice.HeaderText = "ID Chi nhánh";
            colIDBranchOffice.Name = "colIDBranchOffice";
            colIDBranchOffice.ReadOnly = true;
            colIDBranchOffice.Visible = false;
            dgvCustomer.Columns.Add(colIDBranchOffice);
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
            dgvCustomer.Columns.Add(colBranchOfficeName);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvCustomer.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToResizeColumns = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.AutoSize = true;
        }

        public void LoadDataToForm()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = CustomerDAO.Customer_GetAll().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dgvCustomer.DataSource = dt.Copy();
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
        #endregion

        #region Button
        private void btnSearch_Click(object sender, EventArgs e)
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

                ds = CustomerDAO.Customer_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvCustomer.DataSource = ds.Tables[0].Copy();
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
            frmCustomerInsUpd frm = new frmCustomerInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                CustomerDTO obj = new CustomerDTO();
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }
                obj.ID = Convert.ToInt64(txtID.Text);
                obj.Name = txtName.Text;
                obj.Phone = txtPhone.Text;
                obj.Address = txtAddress.Text;
                obj.Description = txtDescription.Text;
                obj.AbilityRent = chkAbilityRent.Checked;
                obj.IDBranchOffice = Convert.ToInt64((cboBranchOffice.SelectedItem as clsComboItem).Value);

                ds = CustomerDAO.Customer_InsUpd(obj);
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

                ds = CustomerDAO.Customer_Del(lID);
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
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvCustomer.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
                txtDescription.Text = row.Cells[4].Value.ToString();
                string sAbilityRent = row.Cells[5].Value.ToString();
                chkAbilityRent.Checked = sAbilityRent == "True" ? true : false;
                object objIDBranchOffice = row.Cells[6].Value;
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
