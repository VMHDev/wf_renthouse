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
    public partial class frmVMHPopup : Form
    {
        private System.Timers.Timer aTimer;

        public frmVMHPopup()
        {
            InitializeComponent();
        }

        public frmVMHPopup(string Message, long Time = 1000)
        {
            InitializeComponent();
            lblMessage.Text = Message;

            aTimer = new System.Timers.Timer(Time);
            aTimer.Enabled = true;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        #region Functions
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            aTimer.Dispose();
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
