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
    public partial class frmPreview : Form
    {
        #region Form
        public frmPreview()
        {
            InitializeComponent();
            dtpPreviewDate.Value = DateTime.Now;
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            InitColumnGridView();
            LoadDataToCombobox();
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
            #region ID Nhà
            DataGridViewColumn colIDHouse = new DataGridViewTextBoxColumn();
            colIDHouse.DataPropertyName = "IDHouse";
            colIDHouse.HeaderText = "ID Nhà";
            colIDHouse.Name = "colIDHouse";
            colIDHouse.ReadOnly = true;
            colIDHouse.Visible = false;
            dgvPreview.Columns.Add(colIDHouse);
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
            dgvPreview.Columns.Add(colCodeHouse);
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
            dgvPreview.Columns.Add(colRoomNumber);
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
            dgvPreview.Columns.Add(colFeeMonth);
            #endregion

            #region ID Khách
            DataGridViewColumn colIDCustomer = new DataGridViewTextBoxColumn();
            colIDCustomer.DataPropertyName = "IDCustomer";
            colIDCustomer.HeaderText = "ID Khách";
            colIDCustomer.Name = "colIDCustomer";
            colIDCustomer.ReadOnly = true;
            colIDCustomer.Visible = false;
            dgvPreview.Columns.Add(colIDCustomer);
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
            dgvPreview.Columns.Add(colNameCustomer);
            #endregion

            #region Ngày xem nhà
            DataGridViewColumn colPreviewDate = new DataGridViewTextBoxColumn();
            colPreviewDate.DataPropertyName = "PreviewDate";
            colPreviewDate.HeaderText = "Ngày xem nhà";
            colPreviewDate.Name = "colPreviewDate";
            colPreviewDate.ReadOnly = true;
            colPreviewDate.Visible = true;
            colPreviewDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStylePreviewDate = new DataGridViewCellStyle();
            dgvCellStylePreviewDate.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStylePreviewDate.Font = new Font("Arial", 12F);
            colPreviewDate.DefaultCellStyle = dgvCellStylePreviewDate;
            dgvPreview.Columns.Add(colPreviewDate);
            #endregion

            #region Nhận xét
            DataGridViewColumn colComment = new DataGridViewTextBoxColumn();
            colComment.DataPropertyName = "Comment";
            colComment.HeaderText = "Nhận xét";
            colComment.Name = "colComment";
            colComment.ReadOnly = true;
            colComment.Visible = true;
            colComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewCellStyle dgvCellStyleComment = new DataGridViewCellStyle();
            dgvCellStyleComment.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleComment.Font = new Font("Arial", 12F);
            colComment.DefaultCellStyle = dgvCellStyleComment;
            dgvPreview.Columns.Add(colComment);
            #endregion

            #region Tùy chỉnh tiêu đề các cột
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Arial", 12F);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvPreview.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            #endregion

            dgvPreview.AutoGenerateColumns = false;
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToResizeColumns = false;
            dgvPreview.AllowUserToResizeRows = false;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.BackgroundColor = Color.White;
            dgvPreview.AutoSize = true;
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

        public void LoadDataToForm()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds = PreviewDAO.Preview_GetAll().Copy();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dgvPreview.DataSource = dt.Copy();
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
                PreviewDTO obj = new PreviewDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.PreviewDate = dtpPreviewDate.Value.Date;

                ds = PreviewDAO.Preview_Search(obj);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvPreview.DataSource = ds.Tables[0].Copy();
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
            frmPreviewInsUpd frm = new frmPreviewInsUpd(this);
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (string.IsNullOrWhiteSpace(cboCustomer.Text) || string.IsNullOrWhiteSpace(cboHouse.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn sửa!");
                    return;
                }

                PreviewDTO obj = new PreviewDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.PreviewDate = dtpPreviewDate.Value.Date;
                obj.Comment = txtComment.Text;

                ds = PreviewDAO.Preview_InsUpd(obj);
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
                if (string.IsNullOrWhiteSpace(cboCustomer.Text) || string.IsNullOrWhiteSpace(cboHouse.Text))
                {
                    clsMessages.ShowInformation("Vui lòng chọn dòng dữ liệu muốn xóa!");
                    return;
                }
                PreviewDTO obj = new PreviewDTO();
                obj.IDHouse = Convert.ToInt64((cboHouse.SelectedItem as clsComboItem).Value);
                obj.IDCustomer = Convert.ToInt64((cboCustomer.SelectedItem as clsComboItem).Value);
                obj.PreviewDate = dtpPreviewDate.Value.Date;


                ds = PreviewDAO.Preview_Del(obj);
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
        private void dgvPreview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                // Thiết lập chọn từng dòng
                dgvPreview.Rows[e.RowIndex].Selected = true;

                // Load data from grid to control
                DataGridViewRow row = dgvPreview.Rows[e.RowIndex];
                object objIDHouse = row.Cells[0].Value;
                clsComboItem itemHouse = clsComboItem.GetItemCombo(objIDHouse, cboHouse);
                cboHouse.SelectedItem = itemHouse;
                object objIDCustomer = row.Cells[4].Value;
                clsComboItem itemCustomer = clsComboItem.GetItemCombo(objIDCustomer, cboCustomer);
                cboCustomer.SelectedItem = itemCustomer;
                dtpPreviewDate.Text = row.Cells[6].Value.ToString();
                txtComment.Text = row.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
            }
        }
        #endregion
    }
}
