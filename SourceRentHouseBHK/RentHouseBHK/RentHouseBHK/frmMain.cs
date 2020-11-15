using RentHouseBHK.BHKGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouseBHK
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region 
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmCustomer))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmCustomer
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            //List<Form> openForms = new List<Form>();

            //foreach (Form f in Application.OpenForms)
            //    openForms.Add(f);

            //foreach (Form f in openForms)
            //{
            //    if (f.GetType() != typeof(frmMain))
            //        f.Close();
            //}

            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmEmployee))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmEmployee
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnHouse_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmHouse))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmHouse
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnHouseholder_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmHouseholder))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmHouseholder
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnBranchOffice_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmBranchOffice))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmBranchOffice
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmLocation))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmLocation
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnHouseType_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmHouseType))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmHouseType
            {
                MdiParent = this
            };
            frmChild.Show();
        }
        #endregion

        #region Functions
        private void btnPreview_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmPreview))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmPreview
            {
                MdiParent = this
            };
            frmChild.Show();
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            foreach (Form frmCheck in MdiChildren)
            {
                if (frmCheck.GetType() == typeof(frmContract))
                {
                    frmCheck.Activate();
                    return;
                }
            }
            Form frmChild = new frmContract
            {
                MdiParent = this
            };
            frmChild.Show();
        }
        #endregion

        #region System
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass();
            frm.ShowDialog();
        }
        #endregion
    }
}
