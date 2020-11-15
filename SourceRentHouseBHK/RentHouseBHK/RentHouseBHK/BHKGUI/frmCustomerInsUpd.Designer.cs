namespace RentHouseBHK.BHKGUI
{
    partial class frmCustomerInsUpd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerInsUpd));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.imageListButton = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.chkAbilityRent = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBranchOffice = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 149);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(716, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 4;
            this.btnClose.ImageList = this.imageListButton;
            this.btnClose.Location = new System.Drawing.Point(613, 3);
            this.btnClose.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnClose.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "     Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageListButton
            // 
            this.imageListButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButton.ImageStream")));
            this.imageListButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListButton.Images.SetKeyName(0, "01_Search_16x16.png");
            this.imageListButton.Images.SetKeyName(1, "02_Add_16x16.png");
            this.imageListButton.Images.SetKeyName(2, "03_Edit_16x16.png");
            this.imageListButton.Images.SetKeyName(3, "04_DeleteList_16x16.png");
            this.imageListButton.Images.SetKeyName(4, "05_Close_16x16.png");
            this.imageListButton.Images.SetKeyName(5, "06_Save_16x16.png");
            this.imageListButton.Images.SetKeyName(6, "07_ListBox_16x16.png");
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageIndex = 5;
            this.btnSave.ImageList = this.imageListButton;
            this.btnSave.Location = new System.Drawing.Point(507, 3);
            this.btnSave.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnSave.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "     Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkAbilityRent, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboBranchOffice, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 149);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điện thoại";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(370, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Địa chỉ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(370, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Yêu cầu";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Font = new System.Drawing.Font("Arial", 12F);
            this.txtID.Location = new System.Drawing.Point(107, 32);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(237, 26);
            this.txtID.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtName.Location = new System.Drawing.Point(107, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 26);
            this.txtName.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPhone.Location = new System.Drawing.Point(107, 90);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(237, 26);
            this.txtPhone.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAddress.Location = new System.Drawing.Point(474, 32);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(239, 26);
            this.txtAddress.TabIndex = 9;
            // 
            // chkAbilityRent
            // 
            this.chkAbilityRent.AutoSize = true;
            this.chkAbilityRent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAbilityRent.Font = new System.Drawing.Font("Arial", 12F);
            this.chkAbilityRent.Location = new System.Drawing.Point(474, 119);
            this.chkAbilityRent.Name = "chkAbilityRent";
            this.chkAbilityRent.Size = new System.Drawing.Size(239, 27);
            this.chkAbilityRent.TabIndex = 12;
            this.chkAbilityRent.Text = "Khả năng tài chính";
            this.chkAbilityRent.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 5);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(710, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "Thêm thông tin khách hàng";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(3, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chi nhánh";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboBranchOffice
            // 
            this.cboBranchOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBranchOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchOffice.Font = new System.Drawing.Font("Arial", 12F);
            this.cboBranchOffice.FormattingEnabled = true;
            this.cboBranchOffice.Location = new System.Drawing.Point(107, 119);
            this.cboBranchOffice.Name = "cboBranchOffice";
            this.cboBranchOffice.Size = new System.Drawing.Size(237, 26);
            this.cboBranchOffice.TabIndex = 11;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDescription.Location = new System.Drawing.Point(474, 61);
            this.txtDescription.Name = "txtDescription";
            this.tableLayoutPanel1.SetRowSpan(this.txtDescription, 2);
            this.txtDescription.Size = new System.Drawing.Size(239, 52);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.Text = "";
            // 
            // frmCustomerInsUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 185);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmCustomerInsUpd";
            this.Text = "Thêm khách hàng";
            this.Load += new System.EventHandler(this.frmCustomerInsUpd_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cboBranchOffice;
        private System.Windows.Forms.CheckBox chkAbilityRent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageListButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtDescription;
    }
}