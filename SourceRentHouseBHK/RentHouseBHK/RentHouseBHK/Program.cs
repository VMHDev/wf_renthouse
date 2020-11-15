using RentHouseBHK.BHKBUS;
using RentHouseBHK.BHKGUI;
using RentHouseBHK.BHKUtilities.BHKMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouseBHK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int result = ConnectDatabase();
            if (result == 1)
            {
                Application.Run(new frmLogin());
            }
            else if(result == 0)
            {
                Application.Run(new frmConnectDatabase(1));
            }
            else
            {
                Application.Run(new frmConnectDatabase(0));
            }
        }

        private static int ConnectDatabase()
        {
            try
            {
                BHKBUS.clsSystemProperties.objDatabase = new clsDatabase();
                string sPathFile = Application.StartupPath + "\\Config.xml";        // File Config.xml phải được đặt trong bin/Release hay bin/Debug
                BHKBUS.clsSystemProperties.objDatabase.ConnectionString = BHKBUS.clsSystemProperties.objDatabase.GetConnectionString(sPathFile);
                bool bSate = BHKBUS.clsSystemProperties.objDatabase.ConnectDatabase();
                if (!bSate)
                {
                    clsMessages.ShowInformation("Không kết nối được với cơ sở dữ liệu");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                clsMessages.ShowError("Không kết nối được với cơ sở dữ liệu!\n" + ex.Message);
                return -1;
            }
            return 1;
        }
    }
}
