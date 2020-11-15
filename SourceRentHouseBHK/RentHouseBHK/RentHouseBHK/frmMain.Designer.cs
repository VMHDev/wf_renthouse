namespace RentHouseBHK
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonMain = new System.Windows.Forms.Ribbon();
            this.tabFunctions = new System.Windows.Forms.RibbonTab();
            this.pnlFunctions = new System.Windows.Forms.RibbonPanel();
            this.btnPreview = new System.Windows.Forms.RibbonButton();
            this.btnContract = new System.Windows.Forms.RibbonButton();
            this.tabCategories = new System.Windows.Forms.RibbonTab();
            this.pnlHouse = new System.Windows.Forms.RibbonPanel();
            this.btnHouse = new System.Windows.Forms.RibbonButton();
            this.btnHouseholder = new System.Windows.Forms.RibbonButton();
            this.btnHouseType = new System.Windows.Forms.RibbonButton();
            this.pnlOffice = new System.Windows.Forms.RibbonPanel();
            this.btnEmployee = new System.Windows.Forms.RibbonButton();
            this.btnBranchOffice = new System.Windows.Forms.RibbonButton();
            this.pnlCustomer = new System.Windows.Forms.RibbonPanel();
            this.btnCustomer = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.btnLocation = new System.Windows.Forms.RibbonButton();
            this.tabSystem = new System.Windows.Forms.RibbonTab();
            this.pnlSystem = new System.Windows.Forms.RibbonPanel();
            this.btnLogin = new System.Windows.Forms.RibbonButton();
            this.btnChangePass = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.Minimized = false;
            this.ribbonMain.Name = "ribbonMain";
            // 
            // 
            // 
            this.ribbonMain.OrbDropDown.BorderRoundness = 8;
            this.ribbonMain.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.OrbDropDown.Name = "";
            this.ribbonMain.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbonMain.OrbDropDown.TabIndex = 0;
            this.ribbonMain.OrbImage = ((System.Drawing.Image)(resources.GetObject("ribbonMain.OrbImage")));
            // 
            // 
            // 
            this.ribbonMain.QuickAccessToolbar.Image = ((System.Drawing.Image)(resources.GetObject("ribbonMain.QuickAccessToolbar.Image")));
            this.ribbonMain.QuickAccessToolbar.Visible = false;
            this.ribbonMain.RibbonTabFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonMain.Size = new System.Drawing.Size(1065, 162);
            this.ribbonMain.TabIndex = 0;
            this.ribbonMain.Tabs.Add(this.tabFunctions);
            this.ribbonMain.Tabs.Add(this.tabCategories);
            this.ribbonMain.Tabs.Add(this.tabSystem);
            this.ribbonMain.Text = "Ribbon Main";
            // 
            // tabFunctions
            // 
            this.tabFunctions.Name = "tabFunctions";
            this.tabFunctions.Panels.Add(this.pnlFunctions);
            this.tabFunctions.Text = "Nghiệp vụ";
            // 
            // pnlFunctions
            // 
            this.pnlFunctions.Items.Add(this.btnPreview);
            this.pnlFunctions.Items.Add(this.btnContract);
            this.pnlFunctions.Name = "pnlFunctions";
            this.pnlFunctions.Text = "Giao dịch";
            // 
            // btnPreview
            // 
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPreview.LargeImage")));
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPreview.SmallImage")));
            this.btnPreview.Text = "Xem nhà";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnContract
            // 
            this.btnContract.Image = ((System.Drawing.Image)(resources.GetObject("btnContract.Image")));
            this.btnContract.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnContract.LargeImage")));
            this.btnContract.Name = "btnContract";
            this.btnContract.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnContract.SmallImage")));
            this.btnContract.Text = "Hợp đồng";
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // tabCategories
            // 
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Panels.Add(this.pnlHouse);
            this.tabCategories.Panels.Add(this.pnlOffice);
            this.tabCategories.Panels.Add(this.pnlCustomer);
            this.tabCategories.Text = "Danh mục";
            // 
            // pnlHouse
            // 
            this.pnlHouse.Items.Add(this.btnHouse);
            this.pnlHouse.Items.Add(this.btnHouseholder);
            this.pnlHouse.Items.Add(this.btnHouseType);
            this.pnlHouse.Name = "pnlHouse";
            this.pnlHouse.Text = "Nhà";
            // 
            // btnHouse
            // 
            this.btnHouse.Image = ((System.Drawing.Image)(resources.GetObject("btnHouse.Image")));
            this.btnHouse.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHouse.LargeImage")));
            this.btnHouse.Name = "btnHouse";
            this.btnHouse.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHouse.SmallImage")));
            this.btnHouse.Text = "Nhà thuê";
            this.btnHouse.Click += new System.EventHandler(this.btnHouse_Click);
            // 
            // btnHouseholder
            // 
            this.btnHouseholder.Image = ((System.Drawing.Image)(resources.GetObject("btnHouseholder.Image")));
            this.btnHouseholder.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHouseholder.LargeImage")));
            this.btnHouseholder.Name = "btnHouseholder";
            this.btnHouseholder.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHouseholder.SmallImage")));
            this.btnHouseholder.Text = "Chủ nhà";
            this.btnHouseholder.Click += new System.EventHandler(this.btnHouseholder_Click);
            // 
            // btnHouseType
            // 
            this.btnHouseType.Image = ((System.Drawing.Image)(resources.GetObject("btnHouseType.Image")));
            this.btnHouseType.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHouseType.LargeImage")));
            this.btnHouseType.Name = "btnHouseType";
            this.btnHouseType.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHouseType.SmallImage")));
            this.btnHouseType.Text = "Loại nhà";
            this.btnHouseType.Click += new System.EventHandler(this.btnHouseType_Click);
            // 
            // pnlOffice
            // 
            this.pnlOffice.Items.Add(this.btnEmployee);
            this.pnlOffice.Items.Add(this.btnBranchOffice);
            this.pnlOffice.Name = "pnlOffice";
            this.pnlOffice.Text = "Nội bộ";
            // 
            // btnEmployee
            // 
            this.btnEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.Image")));
            this.btnEmployee.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.LargeImage")));
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.SmallImage")));
            this.btnEmployee.Text = "Nhân viên";
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnBranchOffice
            // 
            this.btnBranchOffice.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchOffice.Image")));
            this.btnBranchOffice.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBranchOffice.LargeImage")));
            this.btnBranchOffice.Name = "btnBranchOffice";
            this.btnBranchOffice.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBranchOffice.SmallImage")));
            this.btnBranchOffice.Text = "Chi nhánh";
            this.btnBranchOffice.Click += new System.EventHandler(this.btnBranchOffice_Click);
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Items.Add(this.btnCustomer);
            this.pnlCustomer.Items.Add(this.btnLocation);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Text = "Khách hàng";
            // 
            // btnCustomer
            // 
            this.btnCustomer.DropDownItems.Add(this.ribbonButton1);
            this.btnCustomer.DropDownItems.Add(this.ribbonButton2);
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.LargeImage")));
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.SmallImage")));
            this.btnCustomer.Text = "Khách hàng";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            this.ribbonButton1.Visible = false;
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            this.ribbonButton2.Visible = false;
            // 
            // btnLocation
            // 
            this.btnLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnLocation.Image")));
            this.btnLocation.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLocation.LargeImage")));
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLocation.SmallImage")));
            this.btnLocation.Text = "Địa điểm";
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // tabSystem
            // 
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Panels.Add(this.pnlSystem);
            this.tabSystem.Text = "Hệ thống";
            // 
            // pnlSystem
            // 
            this.pnlSystem.Items.Add(this.btnLogin);
            this.pnlSystem.Items.Add(this.btnChangePass);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Text = "Người dùng";
            // 
            // btnLogin
            // 
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.LargeImage")));
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.SmallImage")));
            this.btnLogin.Text = "Đăng xuất";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePass.Image")));
            this.btnChangePass.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChangePass.LargeImage")));
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnChangePass.SmallImage")));
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 670);
            this.Controls.Add(this.ribbonMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentHouseBHK - Quản lý thuê nhà";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbonMain;
        private System.Windows.Forms.RibbonTab tabCategories;
        private System.Windows.Forms.RibbonTab tabFunctions;
        private System.Windows.Forms.RibbonPanel pnlHouse;
        private System.Windows.Forms.RibbonButton btnCustomer;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton btnEmployee;
        private System.Windows.Forms.RibbonButton btnBranchOffice;
        private System.Windows.Forms.RibbonPanel pnlFunctions;
        private System.Windows.Forms.RibbonButton btnPreview;
        private System.Windows.Forms.RibbonButton btnContract;
        private System.Windows.Forms.RibbonPanel pnlOffice;
        private System.Windows.Forms.RibbonPanel pnlCustomer;
        private System.Windows.Forms.RibbonButton btnHouse;
        private System.Windows.Forms.RibbonButton btnHouseholder;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton btnLocation;
        private System.Windows.Forms.RibbonButton btnHouseType;
        private System.Windows.Forms.RibbonTab tabSystem;
        private System.Windows.Forms.RibbonPanel pnlSystem;
        private System.Windows.Forms.RibbonButton btnLogin;
        private System.Windows.Forms.RibbonButton btnChangePass;
    }
}

