using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace RentHouseBHK.BHKUtilities.BHKMessages
{
    public partial class frmVMHMessages : Form
    {
        private System.Timers.Timer aTimer;

        public frmVMHMessages()
        {
            InitializeComponent();
        }

        public frmVMHMessages(string Title, string Message, string OKButton, string CancelButton, ICon icon, bool bAutoClose = false, long Time = 1000)
        {
            InitializeComponent();
            this.Text = Title;
            btnOK.Text = OKButton;
            btnCancel.Text = CancelButton;
            lblMessage.Text = Message;

            if (OKButton == "")
            {
                btnOK.Dispose();
            }

            if (CancelButton == "")
            {
                btnCancel.Dispose();
                btnOK.Location = new System.Drawing.Point(203, 56);
            }

            SetIcon(icon);

            if (bAutoClose)
            {
                aTimer = new System.Timers.Timer(Time);
                aTimer.Enabled = true;
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            }
        }

        #region Functions
        private void SetIcon(ICon icon)
        {
            switch (icon)
            {
                case ICon.Information:
                    pictureBox.Image = imageListIcon.Images[0];
                    break;
                case ICon.Error:
                    pictureBox.Image = imageListIcon.Images[1];
                    break;
                case ICon.QuestionMark:
                    pictureBox.Image = imageListIcon.Images[2];
                    break;
                case ICon.Warning:
                    pictureBox.Image = imageListIcon.Images[3];
                    break;
                default:
                    pictureBox.Image = imageListIcon.Images[0];
                    break;
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            aTimer.Dispose();
            btnOK_Click(null, null);
        }
        #endregion

        #region Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
