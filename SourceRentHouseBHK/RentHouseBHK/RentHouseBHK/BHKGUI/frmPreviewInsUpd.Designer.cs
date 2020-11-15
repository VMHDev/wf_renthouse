namespace RentHouseBHK.BHKGUI
{
    partial class frmPreviewInsUpd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreviewInsUpd));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.imageListButton = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPreviewDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHouse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 167);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(682, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 4;
            this.btnClose.ImageList = this.imageListButton;
            this.btnClose.Location = new System.Drawing.Point(579, 3);
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
            this.btnSave.Location = new System.Drawing.Point(473, 3);
            this.btnSave.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnSave.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "     Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 167);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpPreviewDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboHouse, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtComment, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 167);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 5);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(676, 33);
            this.label6.TabIndex = 11;
            this.label6.Text = "Thêm thông tin xem nhà";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 33);
            this.label4.TabIndex = 1;
            this.label4.Text = "Khách hàng";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(102, 36);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(225, 26);
            this.cboCustomer.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày xem";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPreviewDate
            // 
            this.dtpPreviewDate.CalendarFont = new System.Drawing.Font("Arial", 12F);
            this.dtpPreviewDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPreviewDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPreviewDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpPreviewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPreviewDate.Location = new System.Drawing.Point(102, 69);
            this.dtpPreviewDate.Name = "dtpPreviewDate";
            this.dtpPreviewDate.Size = new System.Drawing.Size(225, 26);
            this.dtpPreviewDate.TabIndex = 12;
            this.dtpPreviewDate.Value = new System.DateTime(2019, 8, 19, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(353, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 33);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nhà";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboHouse
            // 
            this.cboHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cboHouse.FormattingEnabled = true;
            this.cboHouse.Location = new System.Drawing.Point(452, 36);
            this.cboHouse.Name = "cboHouse";
            this.cboHouse.Size = new System.Drawing.Size(227, 26);
            this.cboHouse.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhận xét";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtComment, 4);
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Font = new System.Drawing.Font("Arial", 12F);
            this.txtComment.Location = new System.Drawing.Point(102, 102);
            this.txtComment.Name = "txtComment";
            this.tableLayoutPanel1.SetRowSpan(this.txtComment, 2);
            this.txtComment.Size = new System.Drawing.Size(577, 62);
            this.txtComment.TabIndex = 15;
            this.txtComment.Text = "";
            // 
            // frmPreviewInsUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 203);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmPreviewInsUpd";
            this.Text = "Thêm xem nhà";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageListButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpPreviewDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHouse;
        private System.Windows.Forms.RichTextBox txtComment;
    }
}