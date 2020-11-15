using RentHouseBHK.BHKBUS;
using RentHouseBHK.BHKUtilities.BHKMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RentHouseBHK.BHKGUI
{
    public partial class frmConnectDatabase : Form
    {
        public string PathFile { get; set; }
        public frmConnectDatabase()
        {
            InitializeComponent();
        }

        public frmConnectDatabase(int _Status)
        {
            InitializeComponent();
            #region Load thông tin cấu hình database lên form
            if (_Status == 1)
            {
                BHKBUS.clsSystemProperties.objDatabase = new clsDatabase();
                string[] Info = new string[0];
                try
                {
                    Info = BHKBUS.clsSystemProperties.objDatabase.GetDatabaseInfo(PathFile);
                    txtServer.Text = Info[0];
                    txtDatabase.Text = Info[1];
                    txtUser.Text = Info[2];
                    txtPassword.Text = Info[3];
                }
                catch (Exception ex)
                {
                    clsMessages.ShowError("Không kết nối được với cơ sở dữ liệu!\n" + ex.Message);
                    return;
                }
            }
            #endregion
        }

        private void frmConnectDatabase_Load(object sender, EventArgs e)
        {
            CheckFileExists();
        }

        private void CheckFileExists()
        {
            PathFile = Application.StartupPath + "\\Config.xml";        // File ConfigDatabase.xml phải được đặt trong bin/Release hay bin/Debug
            if (!File.Exists(PathFile))
            {
                clsXML.CreateXMLDocumentConfig("Config.xml");
                PathFile = Application.StartupPath + "\\Config.xml";
            }
        }

        private bool SaveConnect()
        {
            try
            {
                string sEncryptionPass = clsEncryption.EncryptText(txtPassword.Text.Trim());
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(PathFile);
                XMLDoc = clsXML.UpdateXMLDocument(XMLDoc, "SERVER", txtServer.Text.Trim());
                XMLDoc = clsXML.UpdateXMLDocument(XMLDoc, "DATABASE", txtDatabase.Text.Trim());
                XMLDoc = clsXML.UpdateXMLDocument(XMLDoc, "USER", txtUser.Text.Trim());
                XMLDoc = clsXML.UpdateXMLDocument(XMLDoc, "PASSWORD", sEncryptionPass);
                XMLDoc.Save(PathFile);
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
                return false;
            }
            return true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            BHKBUS.clsSystemProperties.objDatabase = new clsDatabase();
            BHKBUS.clsSystemProperties.objDatabase.ConnectionString = BHKBUS.clsSystemProperties.objDatabase.GetConnectionString(PathFile);
            bool bSate = BHKBUS.clsSystemProperties.objDatabase.ConnectDatabase();
            if (!bSate)
            {
                clsMessages.ShowInformation("Không kết nối được với cơ sở dữ liệu");
            }
            else
            {
                clsMessages.ShowInformation("Kết nối thành công với cơ sở dữ liệu");
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(SaveConnect())
            {
                clsMessages.ShowInformation("Lưu thông tin cấu hình thành công!");
            }
            else
            {
                clsMessages.ShowInformation("Lưu thông tin cấu hình thất bại!");
            }
        }

        private void frmConnectDatabase_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }
    }
}
